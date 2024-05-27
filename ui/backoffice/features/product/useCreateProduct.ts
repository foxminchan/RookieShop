import { productService } from "@/lib/inversify";
import { useMutation } from "@tanstack/react-query";
import { CreateProductRequest } from "./product.types";

export function useCreateProduct() {
  return useMutation({
    mutationFn: (data: CreateProductRequest) =>
      productService.createProduct(data),
  });
}
