import { useQuery } from "@tanstack/react-query"

import { PagingFilter } from "@/types/api"

import feedbackService from "./feedback.service"

export default function useListFeedbacks(options?: Partial<PagingFilter>) {
  return useQuery({
    queryKey: [`feedbacks`],
    queryFn: () => feedbackService.listFeedbacks(options),
  })
}
