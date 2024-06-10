import { useEffect, useState } from "react"

import useClaims from "./useClaims"

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
