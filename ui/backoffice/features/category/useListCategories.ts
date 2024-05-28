import { useQuery } from "@tanstack/react-query"
import { categoryService } from "@/lib/inversify"
import { CategoryFilterParams } from "./category.type"
import { buildQueryString } from "@/lib/helpers/query.helper"

export default function useListCategories(
  options?: Partial<CategoryFilterParams>
) {
  return useQuery({
    queryKey: [`categories?${buildQueryString(options)}`],
    queryFn: () => categoryService.listCategories(options),
  })
}
