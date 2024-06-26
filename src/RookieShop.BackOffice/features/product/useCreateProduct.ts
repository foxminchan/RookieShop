import { useMutation } from "@tanstack/react-query"

import productService from "./product.service"
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
