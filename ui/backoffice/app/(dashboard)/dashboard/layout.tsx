"use client"

import { ReactNode, useEffect } from "react"
import { useRouter } from "next/navigation"
import { useAtomValue } from "jotai"

import { userAtom } from "@/lib/jotai/userAtom"
import Header from "@/components/layouts/header"
import Sidebar from "@/components/layouts/sidebar"

export default function MainDashboardLayout({
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
