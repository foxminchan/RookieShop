import { createEnv } from "@t3-oss/env-nextjs"
import { z } from "zod"

export const env = createEnv({
  server: {
    PORT: z.string().min(1).default("3000"),
    REMOTE_BFF: z.string().min(1).url(),
  },
  runtimeEnv: {
    REMOTE_BFF: process.env.REMOTE_BFF,
    PORT: process.env.PORT,
  },
})
