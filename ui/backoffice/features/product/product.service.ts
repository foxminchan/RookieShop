import { buildQueryString } from "@/lib/helpers/query.helper"
import HttpService from "@/lib/services/http.service"

import {
  CreateProductRequest,
  CreateProductResponse,
  ListProducts,
  Product,
  ProductFilterParams,
  UpdateProductRequest,
} from "./product.type"

class ProductService extends HttpService {
  constructor() {
    super()
  }

  getProduct(id: string): Promise<Product> {
    return this.get(`/products/${id}`)
  }

  listProducts(options?: Partial<ProductFilterParams>): Promise<ListProducts> {
    return this.get(`/products?${buildQueryString(options)}`)
  }

  createProduct(data: CreateProductRequest): Promise<CreateProductResponse> {
    let formData = new FormData()
    formData.append("name", data.name)
    formData.append("description", data.description as string)
    formData.append("price", data.price.toString())
    formData.append("priceSale", data.priceSale.toString())
    formData.append("quantity", data.quantity.toString())
    formData.append("categoryId", data.categoryId?.toString() ?? "")
    if (data.productImages) {
      formData.append("image", data.productImages)
    }
    return this.post(`/products`, formData, {
      headers: { "Content-Type": "multipart/form-data" },
    })
  }

  updateProduct(data: UpdateProductRequest): Promise<Product> {
    let formData = new FormData()
    formData.append("id", data.id)
    formData.append("name", data.name)
    formData.append("description", data.description as string)
    formData.append("price", data.price.toString())
    formData.append("priceSale", data.priceSale.toString())
    formData.append("quantity", data.quantity.toString())
    formData.append("categoryId", data.categoryId?.toString() ?? "")
    if (data.productImages) {
      formData.append("image", data.productImages)
    }
    formData.append("status", data.status)
    formData.append(
      "isDeletedOldImage",
      data.isDeletedOldImage?.toString() ?? "false"
    )
    return this.put(`/products`, formData, {
      headers: { "Content-Type": "multipart/form-data" },
    })
  }

  deleteProduct(id: string): Promise<void> {
    return this.delete(`/products/${id}`)
  }
}

export default new ProductService()
