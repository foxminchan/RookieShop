import { AxiosResponse } from "axios"
import { Category } from "./category.type"

export default interface ICategoryService {
  getCategory(id: string): Promise<AxiosResponse<Category>>
}
