import { keepPreviousData, useQuery } from "@tanstack/react-query"

import orderService from "./order.service"

export default function useGetOrder(id: string) {
  return useQuery({
    queryKey: [`orders/${id}`],
    queryFn: () => orderService.getOrder(id),
    placeholderData: keepPreviousData,
  })
}
