import { categoryService } from "@/lib/inversify"
import { keepPreviousData, useQuery } from "@tanstack/react-query"

export default function useCatgeoory(id: string) {
  return useQuery({
    queryKey: [`category-${id}`],
    queryFn: () => categoryService.getCategory(id),
    placeholderData: keepPreviousData,
  })
}
