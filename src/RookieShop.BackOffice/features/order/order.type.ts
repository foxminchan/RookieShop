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
  createdDate: Date
  items: OrderItem[]
}

export type ListOrders = {
  pagedInfo: PagedInfo
  orders: Order[]
}

export type OrderItem = {
  productId: string
  quantity: number
  price: number
}

export enum PaymentMethod {
  Cash = "Cash",
  Card = "Card",
}

export enum OrderStatus {
  Pending = "Pending",
  Shipping = "Shipping",
  Completed = "Completed",
  Cancelled = "Cancelled",
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
