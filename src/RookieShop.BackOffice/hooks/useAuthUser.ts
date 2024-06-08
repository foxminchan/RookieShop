import { useEffect, useState } from "react"
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

function useClaims() {
  return useQuery({
    queryKey: claimsKeys.claim,
    queryFn: async () => {
      const delay = new Promise((resolve) => setTimeout(resolve, 550))
      return Promise.all([fetchClaims(), delay]).then(([claims]) => claims)
    },
    retry: false,
  })
}

export default function useAuthUser() {
  const { data: claims, isLoading } = useClaims()

  let logoutUrl = claims?.find((claim: any) => claim.type === "bff:logout_url")
  let nameDict =
    claims?.find((claim: any) => claim.type === "name") ||
    claims?.find((claim: any) => claim.type === "sub")
  let username = nameDict?.value

  const [isLoggedIn, setIsLoggedIn] = useState(false)
  useEffect(() => {
    setIsLoggedIn(!!username)
  }, [username])

  return {
    username,
    logoutUrl,
    isLoading,
    isLoggedIn,
  }
}
