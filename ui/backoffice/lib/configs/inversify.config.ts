import "reflect-metadata"
import { Container } from "inversify"
import { TYPES } from "../constants/types"
import ProductService from "@/features/product/product.service"
import CategoryService from "@/features/category/category.service"
import IProductService from "@/features/product/product.interface"
import ICategoryService from "@/features/category/category.interface"

const container = new Container()

container.bind<IProductService>(TYPES.IProductService).to(ProductService)
container.bind<ICategoryService>(TYPES.ICategoryService).to(CategoryService)

export { container }
