import { productService } from "@/lib/inversify"
import { keepPreviousData, useQuery } from "@tanstack/react-query"

export default function useProduct(id: string) {
  return useQuery({
    queryKey: [`product-${id}`],
    queryFn: () => productService.getProduct(id),
    placeholderData: keepPreviousData,
  })
}
