import { AxiosResponse } from "axios";
import { Product } from "./product.types";

export default interface IProductService {
  getProduct(id: string): Promise<AxiosResponse<Product>>;
}
