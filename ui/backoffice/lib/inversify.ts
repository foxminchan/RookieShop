import { TYPES } from "./constants/types"
import { container } from "./configs/inversify.config"
import IHttpService from "./interfaces/http.interface"
import IProductService from "@/features/product/product.interface"
import ICategoryService from "@/features/category/category.interface"
import ILocalStorageService from "./interfaces/localStorage.interface"

const httpService = container.get<IHttpService>(TYPES.IHttpService)
const productService = container.get<IProductService>(TYPES.IProductService)
const categoryService = container.get<ICategoryService>(TYPES.ICategoryService)
const localStorageService = container.get<ILocalStorageService>(
  TYPES.ILocalStorageService
)

export { productService, categoryService, localStorageService, httpService }
