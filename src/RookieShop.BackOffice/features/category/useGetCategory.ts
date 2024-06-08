import { keepPreviousData, useQuery } from "@tanstack/react-query"

import categoryService from "./category.service"

export default function useGetCategories(id: string) {
  return useQuery({
    queryKey: [`categories/${id}`],
    queryFn: () => categoryService.getCategory(id),
    placeholderData: keepPreviousData,
  })
}
