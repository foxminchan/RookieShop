import { z } from "zod"
import { createEnv } from "@t3-oss/env-nextjs"

export const env = createEnv({
  client: {
    NEXT_PUBLIC_BASE_API: z.string().min(1).url(),
    NEXT_PUBLIC_DUENDE_AUTHORITY: z.string().min(1).url(),
    NEXT_PUBLIC_DUENDE_CLIENT_ID: z.string().min(1),
    NEXT_PUBLIC_DUENDE_CLIENT_SECRET: z.string().min(1),
    NEXT_PUBLIC_DUENDE_CLIENT_SCOPE: z.string().min(1),
    NEXT_PUBLIC_REDIRECT_URI: z.string().min(1).url(),
    NEXT_PUBLIC_POST_LOGOUT_REDIRECT_URI: z.string().min(1).url(),
    NEXT_PUBLIC_RESPONSE_TYPE: z.string().min(1),
  },
  runtimeEnv: {
    NEXT_PUBLIC_BASE_API: process.env.NEXT_PUBLIC_BASE_API,
    NEXT_PUBLIC_DUENDE_AUTHORITY: process.env.NEXT_PUBLIC_DUENDE_AUTHORITY,
    NEXT_PUBLIC_DUENDE_CLIENT_ID: process.env.NEXT_PUBLIC_DUENDE_CLIENT_ID,
    NEXT_PUBLIC_DUENDE_CLIENT_SECRET:
      process.env.NEXT_PUBLIC_DUENDE_CLIENT_SECRET,
    NEXT_PUBLIC_DUENDE_CLIENT_SCOPE:
      process.env.NEXT_PUBLIC_DUENDE_CLIENT_SCOPE,
    NEXT_PUBLIC_REDIRECT_URI: process.env.NEXT_PUBLIC_REDIRECT_URI,
    NEXT_PUBLIC_POST_LOGOUT_REDIRECT_URI:
      process.env.NEXT_PUBLIC_POST_LOGOUT_REDIRECT_URI,
    NEXT_PUBLIC_RESPONSE_TYPE: process.env.NEXT_PUBLIC_RESPONSE_TYPE,
  },
})
