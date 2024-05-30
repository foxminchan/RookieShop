import {
  Category,
  ListCategories,
  CategoryFilterParams,
  CreateCategoryRequest,
  UpdateCategoryRequest,
  CreateCategoryResponse,
} from "./category.type"
import { v4 as uuidv4 } from "uuid"
import HttpService from "@/lib/services/http.service"
import { buildQueryString } from "@/lib/helpers/query.helper"

class CategoryService extends HttpService {
  constructor() {
    super()
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
}

export default new CategoryService()
