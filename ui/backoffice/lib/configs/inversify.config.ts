import "reflect-metadata"
import { Container } from "inversify"
import { TYPES } from "../constants/types"
import HttpService from "../services/http.service"
import IHttpService from "../interfaces/http.interface"
import ProductService from "@/features/product/product.service"
import CategoryService from "@/features/category/category.service"
import IProductService from "@/features/product/product.interface"
import ICategoryService from "@/features/category/category.interface"
import ILocalStorageService from "../interfaces/localStorage.interface"
import LocalStorageService from "../services/localStorage.service"

const container = new Container()

container.bind<IHttpService>(TYPES.IHttpService).to(HttpService)
container.bind<IProductService>(TYPES.IProductService).to(ProductService)
container.bind<ICategoryService>(TYPES.ICategoryService).to(CategoryService)
container
  .bind<ILocalStorageService>(TYPES.ILocalStorageService)
  .to(LocalStorageService)

export { container }
