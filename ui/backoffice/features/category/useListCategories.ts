import { useQuery } from "@tanstack/react-query"
import categoryService from "./category.service"
import { CategoryFilterParams } from "./category.type"

export default function useListCategories(
  options?: Partial<CategoryFilterParams>
) {
  return useQuery({
    queryKey: [`categories`],
    queryFn: () => categoryService.listCategories(options),
  })
}
