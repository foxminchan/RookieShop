import { buildQueryString } from "@/lib/helpers/query.helper"
import HttpService from "@/lib/services/http.service"

import {
  BestSeller,
  BestSellerProductFilterParams,
  DiffRevenueByMonth,
  DiffRevenueByMonthParams,
  GrownCustomer,
  GrownCustomerParams,
  TodayRevenue,
} from "./report.type"

class ReportService extends HttpService {
  constructor() {
    super()
  }

  getBestSellerProducts(
    options: Partial<BestSellerProductFilterParams>
  ): Promise<BestSeller[]> {
    return this.get(
      `/reports/best-seller-products?${buildQueryString(options)}`
    )
  }

  getDiffRevenueByMonth(
    options: Partial<DiffRevenueByMonthParams>
  ): Promise<DiffRevenueByMonth> {
    return this.get(
      `/reports/diff-revenue-by-month?${buildQueryString(options)}`
    )
  }

  getTodayRevenue(): Promise<TodayRevenue> {
    return this.get("/reports/total-revenue-by-day")
  }

  getGrownCustomer(
    options: Partial<GrownCustomerParams>
  ): Promise<GrownCustomer> {
    return this.get(
      `/reports/customers-grown-by-month?${buildQueryString(options)}`
    )
  }
}

export default new ReportService()
