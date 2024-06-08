import * as z from "zod"

export const categorySchema = z.object({
  name: z.string().min(3).max(50),
  description: z.string().min(3).max(1000),
})
