import categoryService from "./category.service"
import { useMutation } from "@tanstack/react-query"
import { Category, UpdateCategoryRequest } from "./category.type"

export default function useUpdateCategory() {
  return useMutation<Category, AppAxiosError, UpdateCategoryRequest>({
    mutationFn: (data: UpdateCategoryRequest) =>
      categoryService.updateCategory(data),
  })
}
