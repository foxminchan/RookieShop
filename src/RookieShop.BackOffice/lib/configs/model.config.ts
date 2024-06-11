import { env } from "@/env.mjs"
import { AgentState } from "@/types"
import { END, StateGraph } from "@langchain/langgraph"
import { ChatOpenAI } from "@langchain/openai"

export default function model() {
  return new ChatOpenAI({
    temperature: 0.7,
    modelName: env.MODEL_NAME,
  })
}
