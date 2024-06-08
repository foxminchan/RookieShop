import { keepPreviousData, useQuery } from "@tanstack/react-query"

import reportService from "./report.service"

export default function useGetTodayRevenue() {
  return useQuery({
    queryKey: ["total-revenue-by-day"],
    queryFn: () => reportService.getTodayRevenue(),
    placeholderData: keepPreviousData,
  })
}
