import { z } from "zod"
import { createEnv } from "@t3-oss/env-nextjs"

export const env = createEnv({
  server: {
    AUTH_DUENDE_IDENTITY_SERVER6_ISSUER: z.string().min(1).url(),
    AUTH_DUENDE_IDENTITY_SERVER6_ID: z.string().min(1),
    AUTH_DUENDE_IDENTITY_SERVER6_SECRET: z.string().min(1),
    AUTH_SECRET: z.string().min(1),
  },
  client: {
    NEXT_PUBLIC_BASE_API: z.string().min(1).url(),
  },
  runtimeEnv: {
    AUTH_DUENDE_IDENTITY_SERVER6_ISSUER:
      process.env.AUTH_DUENDE_IDENTITY_SERVER6_ISSUER,
    AUTH_DUENDE_IDENTITY_SERVER6_ID:
      process.env.AUTH_DUENDE_IDENTITY_SERVER6_ID,
    AUTH_DUENDE_IDENTITY_SERVER6_SECRET:
      process.env.AUTH_DUENDE_IDENTITY_SERVER6_SECRET,
    AUTH_SECRET: process.env.AUTH_SECRET,
    NEXT_PUBLIC_BASE_API: process.env.NEXT_PUBLIC_BASE_API,
  },
})
