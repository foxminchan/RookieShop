import { buildQueryString } from "@/lib/helpers/query.helper"
import HttpService from "@/lib/services/http.service"

import { ListCategories } from "../category/category.type"
import { Order, OrderFilterParams, UpdateOrderRequest } from "./order.type"

class OrderService extends HttpService {
  constructor() {
    super()
  }

  getOrder(id: string): Promise<Order> {
    return this.get(`/orders/${id}`)
  }

  listOrders(options?: Partial<OrderFilterParams>): Promise<ListCategories> {
    return this.get(`/orders?${buildQueryString(options)}`)
  }

  updateOrder(order: UpdateOrderRequest): Promise<Order> {
    return this.patch(`/orders`, order)
  }
}

export default new OrderService()
