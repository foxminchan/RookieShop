"use client"

import { oidcConfig } from "@/auth"
import { AuthProvider } from "react-oidc-context"

export default function OidcProvider({
  children,
}: Readonly<{
  children: React.ReactNode
}>) {
  return <AuthProvider {...oidcConfig}>{children}</AuthProvider>
}
