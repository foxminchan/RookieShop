import { createEnv } from "@t3-oss/env-nextjs"
import { z } from "zod"

export const env = createEnv({
  server: {
    TAVILY_API_KEY: z.string().min(1),
    OPENAI_API_KEY: z.string().min(1),
    MODEL_NAME: z.string().min(1),
    REMOTE_BFF: z.string().min(1).url(),
    PORT: z.string().min(1).default("3000"),
  },
  runtimeEnv: {
    TAVILY_API_KEY: process.env.TAVILY_API_KEY,
    OPENAI_API_KEY: process.env.OPENAI_API_KEY,
    MODEL_NAME: process.env.MODEL_NAME,
    REMOTE_BFF: process.env.REMOTE_BFF,
    PORT: process.env.PORT,
  },
})
