import "reflect-metadata"
import { Container } from "inversify"
import { TYPES } from "../constants/types"
import IProductService from "@/features/product/product.interface"
import ProductService from "@/features/product/product.service"

const container = new Container()

container.bind<IProductService>(TYPES.IProductService).to(ProductService)

export { container }
