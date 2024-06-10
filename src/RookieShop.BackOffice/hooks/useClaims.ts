import { useQuery } from "@tanstack/react-query"
import axios from "axios"

const claimsKeys = {
  claim: ["claims"],
}

const config = {
  headers: {
    "X-CSRF": "1",
  },
}

const fetchClaims = async () =>
  axios.get("/bff/user", config).then((res) => res.data)

export default function useClaims() {
  return useQuery({
    queryKey: claimsKeys.claim,
    queryFn: async () => {
      const delay = new Promise((resolve) => setTimeout(resolve, 550))
      return Promise.all([fetchClaims(), delay]).then(([claims]) => claims)
    },
    retry: false,
  })
}
