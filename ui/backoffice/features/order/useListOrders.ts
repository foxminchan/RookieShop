import { useQuery } from "@tanstack/react-query"

import orderService from "./order.service"
import { OrderFilterParams } from "./order.type"

export default function useListOrders(options?: Partial<OrderFilterParams>) {
  return useQuery({
    queryKey: [`orders`],
    queryFn: () => orderService.listOrders(options),
  })
}
