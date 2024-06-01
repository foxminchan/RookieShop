import { useMutation } from "@tanstack/react-query"

import feedbackService from "./feedback.service"

export default function useDeleteFeedback() {
  return useMutation<void, AppAxiosError, string>({
    mutationFn: (id: string) => feedbackService.deleteFeedback(id),
  })
}
