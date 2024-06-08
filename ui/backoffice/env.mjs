import { createEnv } from "@t3-oss/env-nextjs"
import { z } from "zod"

export const env = createEnv({
  server: {
    PORT: z.string().min(1).default("3000"),
  },
  client: {
    NEXT_PUBLIC_REMOTE_BFF: z.string().min(1).url(),
  },
  runtimeEnv: {
    NEXT_PUBLIC_REMOTE_BFF: process.env.NEXT_PUBLIC_REMOTE_BFF,
    PORT: process.env.PORT,
  },
})
