import { AxiosResponse } from "axios"
import { Category, ListCategories, CategoryFilterParams } from "./category.type"

export default interface ICategoryService {
  getCategory(id: string): Promise<AxiosResponse<Category>>

  listCategories(
    options?: Partial<CategoryFilterParams>
  ): Promise<AxiosResponse<ListCategories>>
}
