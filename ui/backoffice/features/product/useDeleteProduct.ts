import productService from "./product.service"
import { useMutation } from "@tanstack/react-query"

export default function useDeleteProduct() {
  return useMutation<void, AppAxiosError, string>({
    mutationFn: (id: string) => productService.deleteProduct(id),
  })
}
