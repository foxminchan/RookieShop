import {
  Category,
  ListCategories,
  CategoryFilterParams,
  CreateCategoryRequest,
  UpdateCategoryRequest,
  CreateCategoryResponse,
} from "./category.type"
import HttpService from "@/lib/services/http.service"
import { buildQueryString } from "@/lib/helpers/query.helper"

class CategoryService extends HttpService {
  constructor() {
    super()
  }

  getCategory(id: string): Promise<Category> {
    return this.get(`/categories/${id}`)
  }

  listCategories(
    options?: Partial<CategoryFilterParams>
  ): Promise<ListCategories> {
    return this.get<ListCategories>(`/categories?${buildQueryString(options)}`)
  }

  createCategory(data: CreateCategoryRequest): Promise<CreateCategoryResponse> {
    return this.post(`/categories`, data)
  }

  updateCategory(data: UpdateCategoryRequest): Promise<Category> {
    return this.put(`/categories`, data)
  }

  deleteCategory(id: string): Promise<void> {
    return this.delete(`/categories/${id}`)
  }
}

export default new CategoryService()
