import { Metadata } from "next"
import React from "react"

export const metadata: Metadata = {
  title: "Dashboard",
  description: "Dashboard",
}

type Props = {}

function Layout({ children }: React.PropsWithChildren<Props>) {
  return <>{children}</>
}

export default Layout
