import { buildQueryString } from "@/lib/helpers/query.helper"
import HttpService from "@/lib/services/http.service"

import { BestSeller, BestSellerProductFilterParams } from "./report.type"

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
}

export default new ReportService()
