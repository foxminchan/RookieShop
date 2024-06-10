import { useQuery } from "@tanstack/react-query"
import axios from "axios"

export default function useClaim() {
  return useQuery({
    queryKey: ["claims"],
    queryFn: async () =>
      axios
        .get("/bff/user", {
          headers: {
            "X-CSRF": "1",
          },
        })
        .then((res) => res.data),
    staleTime: Infinity,
    retry: false,
  })
}
