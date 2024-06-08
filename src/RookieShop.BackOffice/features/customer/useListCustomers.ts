import { useQuery } from "@tanstack/react-query"

import customerService from "./customer.service"
import { CustomerFilterParams } from "./customer.type"

export default function useListCustomers(
  options?: Partial<CustomerFilterParams>
) {
  return useQuery({
    queryKey: [`customers`],
    queryFn: () => customerService.listCustomers(options),
  })
}
