"use client"

import { ReactNode, useEffect } from "react"
import { useRouter } from "next/navigation"
import { CopilotKit } from "@copilotkit/react-core"

import useAuthUser from "@/hooks/useAuthUser"
import Header from "@/components/layouts/header"
import Sidebar from "@/components/layouts/sidebar"

export default function MainDashboardLayout({
  children,
}: Readonly<{
  children: ReactNode
}>) {
  const router = useRouter()
  const { isLoggedIn } = useAuthUser()

  useEffect(() => {
    if (isLoggedIn) {
      router.push("/")
    }
  }, [isLoggedIn])

  return (
    <>
      <Header />
      <div className="flex overflow-hidden">
        <Sidebar />
        <CopilotKit runtimeUrl="/api/copilot">
          <main className="w-full pt-16">{children}</main>
        </CopilotKit>
      </div>
    </>
  )
}
