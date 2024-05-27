import { TYPES } from "./constants/types";
import IProductService from "@/features/product/product.interface";
import { container } from "./configs/inversify.config";

const productService = container.get<IProductService>(TYPES.IProductService);

export { productService };
