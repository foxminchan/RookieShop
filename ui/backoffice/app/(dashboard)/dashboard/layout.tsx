import Header from "@/components/layouts/header"
import Sidebar from "@/components/layouts/sidebar"
import type { Metadata } from "next"

export const metadata: Metadata = {
  title: "Dashboard",
  description: "An admin dashboard for managing your app",
}

export default function DashboardLayout({
  children,
}: Readonly<{
  children: React.ReactNode
}>) {
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
