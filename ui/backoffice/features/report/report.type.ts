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

// -- Today Revenue Report

export type TodayRevenue = {
  date: Date
  totalRevenue: number
}

// -- Grown Customer Report

export type GrownCustomer = {
  previousTotalCustomers: number
  currentTotalCustomers: number
  grownCustomers: number
}

export type GrownCustomerParams = {
  month: number
  year: number
}

// -- Order Grown By Day Report

export type OrderGrownByDay = {
  todayCount: number
  yesterdayCount: number
  growthPercentage: number
  currentDate: Date
}
