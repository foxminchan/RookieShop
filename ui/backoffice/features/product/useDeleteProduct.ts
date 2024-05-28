import { productService } from "@/lib/inversify"
import { useMutation } from "@tanstack/react-query"

export default function useDeleteProduct() {
  return useMutation({
    mutationFn: (id: string) => productService.deleteProduct(id),
  })
}
