"use client"

import { ReactNode, useEffect } from "react"
import { useRouter } from "next/navigation"

import useAuthUser from "@/lib/services/auth.service"
import Header from "@/components/layouts/header"
import Sidebar from "@/components/layouts/sidebar"

export default function MainDashboardLayout({
  children,
}: Readonly<{
  children: ReactNode
}>) {
  const router = useRouter()
  const { isLoggedIn } = useAuthUser()

  // useEffect(() => {
  //   if (isLoggedIn) {
  //     router.push("/")
  //   }
  // }, [isLoggedIn])

  return (
    <>
      <Header />
      <div className="flex overflow-hidden">
        <Sidebar />
        <main className="w-full pt-16">{children}</main>
      </div>
    </>
  )
}
