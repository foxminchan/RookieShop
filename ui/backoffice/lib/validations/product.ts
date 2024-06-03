import { ProductStatus } from "@/features/product/product.type"
import * as z from "zod"

import { IMG_MAX_SIZE } from "../constants/default"

const ACCEPTED_IMAGE_MIME_TYPES = ["image/jpeg", "image/png", "image/jpg"]

export const productSchema = z
  .object({
    name: z.string().min(3).max(50),
    description: z.string().min(3).max(1000),
    quantity: z.number().int().positive(),
    price: z.coerce.number().int().positive(),
    priceSale: z.coerce.number().int().positive(),
    productImages: z
      .any()
      .refine(
        (data) => {
          if (data instanceof File) {
            return data.size <= IMG_MAX_SIZE
          }
          return true
        },
        `Image size must be less than ${IMG_MAX_SIZE / 1024 / 1024}MB`
      )
      .refine(
        (data) => {
          if (data instanceof File) {
            return ACCEPTED_IMAGE_MIME_TYPES.includes(data.type)
          }
          return true
        },
        `Image must be in ${ACCEPTED_IMAGE_MIME_TYPES.join(", ")}`
      ),
    status: z.nativeEnum(ProductStatus),
    isDeletedOldImage: z.boolean().optional(),
    categoryId: z.string().optional(),
  })
  .refine((data) => data.priceSale < data.price, {
    message: "Price sale must be less than price",
    path: ["priceSale"],
  })
