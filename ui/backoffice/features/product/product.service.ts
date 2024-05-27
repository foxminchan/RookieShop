import { injectable } from "inversify";
import { Product } from "./product.types";
import { AxiosResponse } from "axios";
import HttpService from "@/lib/services/http.service";
import IProductService from "./product.interface";

@injectable()
export default class ProductService
  extends HttpService
  implements IProductService
{
  constructor() {
    super({
      baseURL: process.env.BASE_URL,
    });
  }

  async getProduct(id: string): Promise<AxiosResponse<Product>> {
    return await this.get<Product>(`/products/${id}`);
  }
}
