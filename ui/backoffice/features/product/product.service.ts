import {
  Product,
  ListProducts,
  ProductFilterParams,
  CreateProductRequest,
  CreateProductResponse,
} from "./product.type"
import HttpService from "@/lib/services/http.service"
import { buildQueryString } from "@/lib/helpers/query.helper"

class ProductService extends HttpService {
  constructor() {
    super()
  }

  getProduct(id: string): Promise<Product> {
    return this.get(`/products/${id}`)
  }

  listProducts(options?: Partial<ProductFilterParams>): Promise<ListProducts> {
    return this.get<ListProducts>(`/products?${buildQueryString(options)}`)
  }

  createProduct(data: CreateProductRequest): Promise<CreateProductResponse> {
    return this.post(`/products`, data)
  }

  updateProduct(data: CreateProductRequest): Promise<Product> {
    return this.put(`/products`, data)
  }

  deleteProduct(id: string): Promise<void> {
    return this.delete(`/products/${id}`)
  }
}

export default new ProductService()
