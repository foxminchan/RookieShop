import React, { PropsWithChildren } from "react"
import { Metadata } from "next"

export const metadata: Metadata = {
  title: "Dashboard",
  description: "Dashboard",
}

export default function DashBoardLayout({
  children,
}: Readonly<PropsWithChildren>) {
  return <>{children}</>
}
