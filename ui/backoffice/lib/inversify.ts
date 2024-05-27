import IProductService from "@/features/product/product.interface";
import { container } from "./configs/inversify.config";
import { TYPES } from "./constants/types";

const productService = container.get<IProductService>(TYPES.IProductService);

export { productService };
