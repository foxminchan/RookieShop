"use client"

import { useEffect } from "react"
import { useRouter } from "next/navigation"
import { authService } from "@/lib/services/auth.service"

export default function SigninCallback() {
  const router = useRouter()

  useEffect(() => {
    async function handleCallback() {
      await authService.userManager.signinRedirectCallback()
      router.push("/dashboard")
    }
    handleCallback()
  }, [router])

  return <p className="text-primary">Redirecting...</p>
}
