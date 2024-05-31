import { keepPreviousData, useQuery } from "@tanstack/react-query"

import productService from "./product.service"

export default function useGetProduct(id: string) {
  return useQuery({
    queryKey: [`products/${id}`],
    queryFn: () => productService.getProduct(id),
    placeholderData: keepPreviousData,
  })
}
