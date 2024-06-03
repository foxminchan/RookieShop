import { PagedInfo, PagingFilter } from "@/types/api"

// --- Types ---

export type Order = {
  id: string
  paymentMethod: PaymentMethod
  last4: string | null
  brand: string | null
  chargeId: string | null
  street: string | null
  city: string | null
  province: string | null
  totalPrice: number
  customerId: string
  orderStatus: OrderStatus
  createDate: Date
  items: OrderItem[]
}

export type ListOrder = {
  pagedInfo: PagedInfo
  orders: Order[]
}

export type OrderItem = {
  productId: string
  quantity: number
  price: number
}

export enum PaymentMethod {
  Cash = 1,
  Card = 2,
}

export enum OrderStatus {
  Pending = 1,
  Shipping = 2,
  Completed = 3,
  Cancelled = 4,
}

export type OrderFilterParams = PagingFilter & {
  status?: OrderStatus | null
  userId?: string | null
  search?: string | null
}

// --- Requests ---

export type UpdateOrderRequest = {
  id: string
  orderStatus: OrderStatus
}
