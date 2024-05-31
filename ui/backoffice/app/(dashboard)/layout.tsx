import { Metadata } from "next"
import React, { PropsWithChildren } from "react"

export const metadata: Metadata = {
  title: "Dashboard",
  description: "Dashboard",
}

export default function DashBoardLayout({
  children,
}: Readonly<PropsWithChildren>) {
  return <>{children}</>
}
