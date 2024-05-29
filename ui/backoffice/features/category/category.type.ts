import { PagingFilter, PagedInfo } from "@/types/api"

export type Category = {
  id: string
  name: string
  description: string
}

export type ListCategories = {
  pageInfo: PagedInfo
  categories: Category[]
}

export type CategoryFilterParams = PagingFilter & {
  search?: string | null
}
