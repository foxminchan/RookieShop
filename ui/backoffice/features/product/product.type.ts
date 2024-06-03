import { FilterParams, PagedInfo } from "@/types/api"

import { Category } from "../category/category.type"

// --- Types ---

export type Product = {
  id: string
  name: string
  description: string
  quantity: number
  price: number
  priceSale: number
  imageUrl: string
  averageRating: number
  totalReviews: number
  status: ProductStatus
  category: Category
}

export type ListProducts = {
  pagedInfo: PagedInfo
  products: Product[]
}

export type ProductFilterParams = FilterParams & {
  search?: string | null
}

// --- Requests ---

export type CreateProductRequest = {
  name: string
  description?: string
  quantity: number
  price: number
  priceSale: number
  productImages?: File
  categoryId?: string
}

export type UpdateProductRequest = {
  id: string
  name: string
  description?: string
  quantity: number
  price: number
  priceSale: number
  productImages?: File
  status: ProductStatus
  isDeletedOldImage: boolean
  categoryId?: string
}

// --- Responses ---

export type CreateProductResponse = {
  id: string
}

export enum ProductStatus {
  InStock = 1,
  OutOfStock = 2,
  Discontinued = 3,
}
