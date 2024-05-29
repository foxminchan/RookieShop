import { ListCategories, CategoryFilterParams } from "./category.type"

export default interface ICategoryService {
  listCategories(
    options?: Partial<CategoryFilterParams>
  ): Promise<ListCategories>
}
