import { PagedInfo } from "@/types/api"

// --- Types ---

export type Feedback = {
  id: string
  productId: string
  rating: number
  content: string
  updatedDate: Date
  customer: FeedbackCustomer
}

export type ListFeedbacks = {
  pagedInfo: PagedInfo
  feedbacks: Feedback[]
}

export type FeedbackCustomer = {
  customerId: string
  customerName: string
}
