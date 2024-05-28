import { env } from "@/env.mjs"
import { AxiosResponse } from "axios"
import { injectable } from "inversify"
import { Category } from "./category.type"
import ICategoryService from "./category.interface"
import HttpService from "@/lib/services/http.service"

@injectable()
export default class CategoryService
  extends HttpService
  implements ICategoryService
{
  constructor() {
    super({
      baseURL: `${env.BASE_API}/categories`,
    })
  }

  async getCategory(id: string): Promise<AxiosResponse<Category>> {
    return await this.get<Category>(`/${id}`)
  }
}
