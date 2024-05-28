import { PagedInfo } from "@/types/api"

export type Category = {
  id: string
  name: string
  description: string
}

export type ListCategories = {
  pagedInfo: PagedInfo
  categories: Category[]
}
