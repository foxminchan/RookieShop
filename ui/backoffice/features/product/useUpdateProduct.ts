import productService from "./product.service"
import { useMutation } from "@tanstack/react-query"
import { Product, UpdateProductRequest } from "./product.type"

export default function useUpdateProduct() {
  return useMutation<Product, AppAxiosError, UpdateProductRequest>({
    mutationFn: (data: UpdateProductRequest) =>
      productService.updateProduct(data),
  })
}
