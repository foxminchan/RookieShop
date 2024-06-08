import { keepPreviousData, useQuery } from "@tanstack/react-query"

import reportService from "./report.service"
import { GrownCustomerParams } from "./report.type"

export default function useGetGrownCustomer(
  options: Partial<GrownCustomerParams>
) {
  return useQuery({
    queryKey: ["grown-customer"],
    queryFn: () => reportService.getGrownCustomer(options),
    placeholderData: keepPreviousData,
  })
}
