import { PagedInfo, PagingFilter } from "@/types/api"

export type Category = {
  id: string
  name: string
  description: string
}

export type ListCategories = {
  pagedInfo: PagedInfo
  categories: Category[]
}

export type CategoryFilterParams = PagingFilter & {
  search?: string | null
}

// --- Requests ---

export type CreateCategoryRequest = {
  name: string
  description?: string
}

export type UpdateCategoryRequest = CreateCategoryRequest & {
  id: string
}

// --- Responses ---

export type CreateCategoryResponse = {
  id: string
}
