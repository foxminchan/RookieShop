import { useMutation } from "@tanstack/react-query"

import categoryService from "./category.service"

export default function useDeleteCategory() {
  return useMutation<void, AppAxiosError, string>({
    mutationFn: (id: string) => categoryService.deleteCategory(id),
  })
}
