export type BestSeller = {
  productId: string
  productName: string
  totalSoldQuantity: number
  imageUrl: string
  price: Price
}

export type Price = {
  price: number
  priceSale: number
}

export type BestSellerProductFilterParams = {
  top: number
}
