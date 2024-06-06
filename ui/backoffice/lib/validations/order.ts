import { OrderStatus } from "@/features/order/order.type"
import { z } from "zod"

export const orderSchema = z.object({
  id: z.string(),
  orderStatus: z.nativeEnum(OrderStatus),
})
