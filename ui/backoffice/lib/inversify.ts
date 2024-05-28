import { TYPES } from "./constants/types"
import IProductService from "@/features/product/product.interface"
import { container } from "./configs/inversify.config"
import ICategoryService from "@/features/category/category.interface"

const productService = container.get<IProductService>(TYPES.IProductService)
const categoryService = container.get<ICategoryService>(TYPES.ICategoryService)

export { productService, categoryService }
