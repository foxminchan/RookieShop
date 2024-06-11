import { AgentState } from "@/types"
import { TavilySearchAPIRetriever } from "@langchain/community/retrievers/tavily_search_api"
import { HumanMessage, SystemMessage } from "@langchain/core/messages"
import { RunnableLambda } from "@langchain/core/runnables"
import { END, START, StateGraph } from "@langchain/langgraph"

import model from "../configs/model.config"

async function search(state: {
  agentState: AgentState
}): Promise<{ agentState: AgentState }> {
  const retriever = new TavilySearchAPIRetriever({
    k: 10,
  })
  let topic = state.agentState.topic
  if (topic.length < 5) {
    topic = "topic: " + topic
  }
  const docs = await retriever.invoke(topic)
  return {
    agentState: {
      ...state.agentState,
      searchResults: JSON.stringify(docs),
    },
  }
}

async function curate(state: {
  agentState: AgentState
}): Promise<{ agentState: AgentState }> {
  const response = await model().invoke(
    [
      new SystemMessage(
        `You are a bookstore content curator.
         Your sole task is to return a list of URLs of the 5 most relevant articles for the provided product or category as a JSON list of strings
         in this format:
         {
          urls: ["url1", "url2", "url3", "url4", "url5"]
         }
         .`.replace(/\s+/g, " ")
      ),
      new HumanMessage(
        `Today's date is ${new Date().toLocaleDateString("en-US")}.
       Product or Category: ${state.agentState.topic}

       Here is a list of articles:
       ${state.agentState.searchResults}`.replace(/\s+/g, " ")
      ),
    ],
    {
      response_format: {
        type: "json_object",
      },
    }
  )
  const urls = JSON.parse(response.content as string).urls
  const searchResults = JSON.parse(state.agentState.searchResults!)
  const newSearchResults = searchResults.filter((result: any) => {
    return urls.includes(result.metadata.source)
  })
  return {
    agentState: {
      ...state.agentState,
      searchResults: JSON.stringify(newSearchResults),
    },
  }
}

async function critique(state: {
  agentState: AgentState
}): Promise<{ agentState: AgentState }> {
  let feedbackInstructions = ""
  if (state.agentState.critique) {
    feedbackInstructions =
      `The writer has revised the description based on your previous critique: ${state.agentState.critique}
       The writer might have left feedback for you encoded between <FEEDBACK> tags.
       The feedback is only for you to see and will be removed from the final description.
    `.replace(/\s+/g, " ")
  }
  const response = await model().invoke([
    new SystemMessage(
      `You are a bookstore description critique. Your sole purpose is to provide short feedback on a written
      description so the writer will know what to fix.
      Today's date is ${new Date().toLocaleDateString("en-US")}
      Your task is to provide really short feedback on the description only if necessary.
      if you think the description is good, please return [DONE].
      You can provide feedback on the revised description or just
      return [DONE] if you think the description is good.
      Please return a string of your critique or [DONE].`.replace(/\s+/g, " ")
    ),
    new HumanMessage(
      `${feedbackInstructions}
       This is the description: ${state.agentState.description}`
    ),
  ])
  const content = response.content as string
  console.log("critique:", content)
  return {
    agentState: {
      ...state.agentState,
      critique: content.includes("[DONE]") ? undefined : content,
    },
  }
}

async function write(state: {
  agentState: AgentState
}): Promise<{ agentState: AgentState }> {
  const response = await model().invoke([
    new SystemMessage(
      `You are a bookstore content writer. Your sole purpose is to write a well-written description about a
      product or category using a list of articles. Write 3 paragraphs in markdown.`.replace(
        /\s+/g,
        " "
      )
    ),
    new HumanMessage(
      `Today's date is ${new Date().toLocaleDateString("en-US")}.
      Your task is to write a compelling description for me about the provided product or
      category based on the sources.
      Here is a list of articles: ${state.agentState.searchResults}
      This is the product or category: ${state.agentState.topic}
      Please return a well-written description based on the provided information.`.replace(
        /\s+/g,
        " "
      )
    ),
  ])
  const content = response.content as string
  return {
    agentState: {
      ...state.agentState,
      description: content,
    },
  }
}

async function revise(state: {
  agentState: AgentState
}): Promise<{ agentState: AgentState }> {
  const response = await model().invoke([
    new SystemMessage(
      `You are a bookstore content editor. Your sole purpose is to edit a well-written description about a
      product or category based on given critique.`.replace(/\s+/g, " ")
    ),
    new HumanMessage(
      `Your task is to edit the description based on the critique given.
      This is the description: ${state.agentState.description}
      This is the critique: ${state.agentState.critique}
      Please return the edited description based on the critique given.
      You may leave feedback about the critique encoded between <FEEDBACK> tags like this:
      <FEEDBACK> here goes the feedback ...</FEEDBACK>`.replace(/\s+/g, " ")
    ),
  ])
  const content = response.content as string
  return {
    agentState: {
      ...state.agentState,
      description: content,
    },
  }
}

const shouldContinue = (state: { agentState: AgentState }) => {
  const result = state.agentState.critique === undefined ? "end" : "continue"
  return result
}

const agentState = {
  agentState: {
    value: (x: AgentState, y: AgentState) => y,
    default: () => ({
      topic: "",
    }),
  },
  __root__: {
    value: (x: any, y: any) => y,
    default: () => ({}),
  },
}

const workflow = new StateGraph({
  channels: agentState,
})

workflow.addNode("search", new RunnableLambda({ func: search }) as any)
workflow.addNode("curate", new RunnableLambda({ func: curate }) as any)
workflow.addNode("write", new RunnableLambda({ func: write }) as any)
workflow.addNode("critique", new RunnableLambda({ func: critique }) as any)
workflow.addNode("revise", new RunnableLambda({ func: revise }) as any)
workflow.addEdge(START, "search" as "__start__")
workflow.addEdge("search" as "__start__", "curate" as "__start__")
workflow.addEdge("curate" as "__start__", "write" as "__start__")
workflow.addEdge("write" as "__start__", "critique" as "__start__")

workflow.addConditionalEdges("critique" as "__start__", shouldContinue, {
  continue: "revise" as "__start__",
  end: END,
})
workflow.addEdge("revise" as "__start__", "critique" as "__start__")

const app = workflow.compile()

export async function researchWithLangGraph(topic: string) {
  const inputs = {
    agentState: {
      topic,
    },
  }
  const result = await app.invoke(inputs)
  const regex = /<FEEDBACK>[\s\S]*?<\/FEEDBACK>/g
  const description = result.agentState.description.replace(regex, "")
  return description
}
