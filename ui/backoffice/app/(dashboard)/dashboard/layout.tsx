"use client"

import Header from "@/components/layouts/header"
import Sidebar from "@/components/layouts/sidebar"
import { userAtom } from "@/lib/services/auth.service"
import { useAtomValue } from "jotai"
import { useRouter } from "next/navigation"
import { useEffect } from "react"

export default function DashboardLayout({
  children,
}: Readonly<{
  children: React.ReactNode
}>) {
  const router = useRouter()
  const user = useAtomValue(userAtom)

  useEffect(() => {
    if (!user) {
      router.push("/")
    }
  }, [user])

  return (
    <>
      <Header />
      <div className="flex h-screen overflow-hidden">
        <Sidebar />
        <main className="w-full pt-16">{children}</main>
      </div>
    </>
  )
}
