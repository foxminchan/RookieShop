import { useQuery } from "@tanstack/react-query"

import reportService from "./report.service"
import { BestSellerProductFilterParams } from "./report.type"

export default function useGetBestSellerProducts(
  options: Partial<BestSellerProductFilterParams>
) {
  return useQuery({
    queryKey: ["best-seller-products"],
    queryFn: () => reportService.getBestSellerProducts(options),
  })
}
