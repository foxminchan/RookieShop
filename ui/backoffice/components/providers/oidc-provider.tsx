"use client"

import { AuthProvider } from "react-oidc-context"

import { oidcConfig } from "@/lib/configs/oicd.config"

export default function OidcProvider({
  children,
}: Readonly<{
  children: React.ReactNode
}>) {
  return <AuthProvider {...oidcConfig}>{children}</AuthProvider>
}
