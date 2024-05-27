import { PagedInfo } from "@/lib/@types/api";
import { Category } from "../category/category.type";

export type Product = {
  id: string;
  name: string;
  description: string;
  quantity: number;
  price: number;
  priceSale: number;
  imageUrl: string;
  averageRating: number;
  totalReviews: number;
  category: Category;
};

export type ListProduct = {
  pagedInfo: PagedInfo;
  products: Product[];
};
