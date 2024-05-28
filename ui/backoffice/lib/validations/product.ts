import * as z from "zod"

export const productSchema = z.object({
  name: z.string().min(3).max(50),
  description: z.string().min(3).max(1000),
  quantity: z.number().int().positive(),
  price: z.number().int().positive(),
  priceSale: z.number().int().positive(),
})
