import HttpService from "@/lib/services/http.service"
import { buildQueryString } from "@/lib/helpers/query.helper"
import { ListCategories, CategoryFilterParams } from "./category.type"

class CategoryService extends HttpService {
  constructor() {
    super()
  }

  listCategories(
    options?: Partial<CategoryFilterParams>
  ): Promise<ListCategories> {
    return this.get<ListCategories>(`/categories?${buildQueryString(options)}`)
  }
}

export default new CategoryService()
