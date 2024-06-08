import { useMutation } from "@tanstack/react-query"

import productService from "./product.service"

export default function useDeleteProduct() {
  return useMutation<void, AppAxiosError, string>({
    mutationFn: (id: string) => productService.deleteProduct(id),
  })
}
