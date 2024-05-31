"use client"

import { useAtomValue } from "jotai"
import { useRouter } from "next/navigation"
import { ReactNode, useEffect } from "react"
import { userAtom } from "@/lib/jotai/userAtom"
import Header from "@/components/layouts/header"
import Sidebar from "@/components/layouts/sidebar"

export default function DashboardLayout({
  children,
}: Readonly<{
  children: ReactNode
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
