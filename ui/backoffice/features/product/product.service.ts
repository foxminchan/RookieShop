import {
  Product,
  ListProduct,
  ProductFilterParams,
  CreateProductRequest,
  UpdateProductRequest,
  CreateProductResponse,
} from "./product.types";
import { env } from "@/env.mjs";
import { v4 as uuidv4 } from "uuid";
import { AxiosResponse } from "axios";
import { injectable } from "inversify";
import IProductService from "./product.interface";
import HttpService from "@/lib/services/http.service";
import { buildQueryString } from "@/lib/helpers/query.helper";

@injectable()
export default class ProductService
  extends HttpService
  implements IProductService
{
  constructor() {
    super({
      baseURL: env.BASE_API as string,
    });
  }

  async getProduct(id: string): Promise<AxiosResponse<Product>> {
    return await this.get<Product>(`/products/${id}`);
  }

  async listProducts(
    options: Partial<ProductFilterParams>,
  ): Promise<AxiosResponse<ListProduct>> {
    const query = buildQueryString(options);
    return await this.get<ListProduct>(`/products?${query}`);
  }

  async createProduct(
    product: CreateProductRequest,
  ): Promise<AxiosResponse<CreateProductResponse>> {
    return await this.post<CreateProductRequest, CreateProductResponse>(
      "/products",
      product,
      {
        headers: {
          "Content-Type": "multipart/form-data",
          "X-Idempotency-Key": uuidv4(),
        },
      },
    );
  }

  async deleteProduct(id: string): Promise<AxiosResponse> {
    return await this.delete(`/products/${id}`);
  }

  async updateProduct(
    product: UpdateProductRequest,
  ): Promise<AxiosResponse<unknown, unknown>> {
    return await this.put<Product>("/products", product);
  }
}
