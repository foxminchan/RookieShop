import { productService } from "@/lib/inversify";
import { useMutation } from "@tanstack/react-query";
import { UpdateProductRequest } from "./product.types";

export function useUpdateProduct() {
  return useMutation({
    mutationFn: (data: UpdateProductRequest) =>
      productService.updateProduct(data),
  });
}
