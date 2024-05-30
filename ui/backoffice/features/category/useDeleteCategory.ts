import categoryService from "./category.service"
import { useMutation } from "@tanstack/react-query"

export default function useDeleteCategory() {
  return useMutation<void, AppAxiosError, string>({
    mutationFn: (id: string) => categoryService.deleteCategory(id),
  })
}
