import { PagedInfo } from "@/types/api"

export type Feedback = {
  id: string
  productId: string
  rating: number
  content: string
  updatedDate: Date
}

export type ListFeedbacks = {
  pagedInfo: PagedInfo
  feedbacks: Feedback[]
}
