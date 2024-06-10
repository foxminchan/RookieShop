import { useEffect, useState } from "react"

import useClaim from "./useClaim"

export default function useAuthUser() {
  const { data: claims, isLoading } = useClaim()

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
