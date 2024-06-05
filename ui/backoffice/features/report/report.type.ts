// -- Best Seller Report
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

// -- Revenue By Month Report
export type DiffRevenueByMonth = {
  sourceMonthYear: string
  targetMonthYear: string
  diff: number
}

export type DiffRevenueByMonthParams = {
  sourceMonth: string
  sourceYear: string
  targetMonth: string
  targetYear: string
}
