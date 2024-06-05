import { useQuery } from "@tanstack/react-query"

import reportService from "./report.service"
import { DiffRevenueByMonthParams } from "./report.type"

export default function useGetDiffRevenueByMonth(
  options: Partial<DiffRevenueByMonthParams>
) {
  return useQuery({
    queryKey: ["diff-revenue-by-month"],
    queryFn: () => reportService.getDiffRevenueByMonth(options),
  })
}
