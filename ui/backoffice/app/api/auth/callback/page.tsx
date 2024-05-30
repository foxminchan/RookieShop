"use client"

import { useEffect } from "react"
import { useRouter } from "next/navigation"
import userManager from "@/lib/configs/oicd.config"

export default function SigninCallback() {
  const router = useRouter()

  useEffect(() => {
    async function handleCallback() {
      await userManager.signinRedirectCallback()
      router.push("/dashboard")
    }
    handleCallback()
  }, [router])

  return <p className="text-primary">Redirecting...</p>
}
