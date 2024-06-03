import { useMutation } from "@tanstack/react-query"

import orderService from "./order.service"
import { Order, UpdateOrderRequest } from "./order.type"

export default function useUpdateOrder() {
  return useMutation<Order, AppAxiosError, UpdateOrderRequest>({
    mutationFn: (data: UpdateOrderRequest) => orderService.updateOrder(data),
  })
}
