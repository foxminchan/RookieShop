import productService from "./product.service"
import { useMutation } from "@tanstack/react-query"
import { CreateProductRequest, CreateProductResponse } from "./product.type"

export default function useCreateProduct() {
  return useMutation<
    CreateProductResponse,
    AppAxiosError,
    CreateProductRequest
  >({
    mutationFn: (data: CreateProductRequest) =>
      productService.createProduct(data),
  })
}
