import { keepPreviousData, useQuery } from "@tanstack/react-query"

import reportService from "./report.service"

export default function useGetOrderGrownByDay() {
  return useQuery({
    queryKey: ["order-grown-by-day"],
    queryFn: () => reportService.getOrderGrownByDay(),
    placeholderData: keepPreviousData,
  })
}
