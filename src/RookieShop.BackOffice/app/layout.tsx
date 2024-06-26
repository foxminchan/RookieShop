import "./globals.css"
import "@copilotkit/react-textarea/styles.css"

import { ReactNode } from "react"
import type { Metadata } from "next"
import { Inter as FontSans } from "next/font/google"
import NextTopLoader from "nextjs-toploader"

import { siteConfig } from "@/lib/configs/site.config"
import { cn } from "@/lib/utils"

import Providers from "./providers"

const fontSans = FontSans({
  subsets: ["latin"],
  variable: "--font-sans",
})

export const metadata: Metadata = {
  title: {
    default: siteConfig.name,
    template: `%s | ${siteConfig.name}`,
  },
  description: siteConfig.description,
  keywords: siteConfig.keywords,
  authors: siteConfig.authors,
  openGraph: {
    type: "website",
    locale: "en_US",
    images: siteConfig.ogImage,
    title: siteConfig.name,
    description: siteConfig.description,
    siteName: siteConfig.name,
  },
}

export default async function Layout({
  children,
}: Readonly<{
  children: ReactNode
}>) {
  return (
    <html lang="en" suppressHydrationWarning>
      <body
        className={cn(
          "min-h-screen bg-background font-sans antialiased",
          fontSans.variable
        )}
      >
        <NextTopLoader />
        <Providers>{children}</Providers>
      </body>
    </html>
  )
}
