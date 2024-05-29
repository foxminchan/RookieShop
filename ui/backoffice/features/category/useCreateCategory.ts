import categoryService from "./category.service"
import { useMutation } from "@tanstack/react-query"
import { CreateCategoryRequest, CreateCategoryResponse } from "./category.type"

export default function useCreateCategory() {
  return useMutation<
    CreateCategoryResponse,
    AppAxiosError,
    CreateCategoryRequest
  >({
    mutationFn: (data: CreateCategoryRequest) =>
      categoryService.createCategory(data),
  })
}
