import { buildQueryString } from "@/lib/helpers/query.helper"
import HttpService from "@/lib/services/http.service"

import { CustomerFilterParams, ListCustomers } from "./customer.type"

class CustomerService extends HttpService {
  constructor() {
    super()
  }

  listCustomers(
    options?: Partial<CustomerFilterParams>
  ): Promise<ListCustomers> {
    return this.get(`/customers?${buildQueryString(options)}`)
  }
}

export default new CustomerService()
