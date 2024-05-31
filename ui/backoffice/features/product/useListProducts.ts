import productService from "./product.service"
import { useQuery } from "@tanstack/react-query"
import { ProductFilterParams } from "./product.types"

export default function useListProducts(
  options?: Partial<ProductFilterParams>
) {
  return useQuery({
    queryKey: [`products`],
    queryFn: () => productService.listProducts(options),
  })
}
