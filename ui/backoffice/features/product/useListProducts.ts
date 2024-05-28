import { productService } from "@/lib/inversify"
import { useQuery } from "@tanstack/react-query"
import { ProductFilterParams } from "./product.types"
import { buildQueryString } from "@/lib/helpers/query.helper"

export default function useListProducts(options: Partial<ProductFilterParams>) {
  return useQuery({
    queryKey: [`products?${buildQueryString(options)}`],
    queryFn: () => productService.listProducts(options),
  })
}
