import { useQuery } from "@tanstack/react-query"

import productService from "./product.service"
import { ProductFilterParams } from "./product.type"

export default function useListProducts(
  options?: Partial<ProductFilterParams>
) {
  return useQuery({
    queryKey: [`products`],
    queryFn: () => productService.listProducts(options),
  })
}
