import { AxiosResponse } from "axios"
import {
  CreateProductRequest,
  CreateProductResponse,
  ListProduct,
  Product,
  ProductFilterParams,
  UpdateProductRequest,
} from "./product.types"

export default interface IProductService {
  getProduct(id: string): Promise<AxiosResponse<Product>>

  listProducts(
    options: Partial<ProductFilterParams>
  ): Promise<AxiosResponse<ListProduct>>

  createProduct(
    product: CreateProductRequest
  ): Promise<AxiosResponse<CreateProductResponse>>

  deleteProduct(id: string): Promise<AxiosResponse>

  updateProduct(
    product: UpdateProductRequest
  ): Promise<AxiosResponse<unknown, unknown>>
}
