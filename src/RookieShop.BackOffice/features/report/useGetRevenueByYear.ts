import { useQuery } from "@tanstack/react-query"

import reportService from "./report.service"
import { RevenueByYearParams } from "./report.type"

export default function useGetRevenueByYear(
  options: Partial<RevenueByYearParams>
) {
  return useQuery({
    queryKey: ["revenue-by-year", options],
    queryFn: () => reportService.getRevenueByYear(options),
  })
}
