import categoryService from "./category.service"
import { keepPreviousData, useQuery } from "@tanstack/react-query"

export default function useListCategories(id: string) {
  return useQuery({
    queryKey: [`categories/${id}`],
    queryFn: () => categoryService.getCategory(id),
    placeholderData: keepPreviousData,
  })
}
