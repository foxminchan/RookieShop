import { PagingFilter } from "@/types/api"
import { buildQueryString } from "@/lib/helpers/query.helper"
import HttpService from "@/lib/services/http.service"

import { ListFeedbacks } from "./feedback.type"

class FeedbackService extends HttpService {
  constructor() {
    super()
  }

  listFeedbacks(options?: Partial<PagingFilter>): Promise<ListFeedbacks> {
    return this.get(`/feedbacks?${buildQueryString(options)}`)
  }

  deleteFeedback(id: string): Promise<void> {
    return this.delete(`/feedbacks/${id}`)
  }
}

export default new FeedbackService()
