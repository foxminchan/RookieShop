import "./globals.css";
import { auth } from "@/auth";
import { cn } from "@/lib/utils";
import { ReactNode } from "react";
import Providers from "./providers";
import type { Metadata } from "next";
import NextTopLoader from "nextjs-toploader";
import { Inter as FontSans } from "next/font/google";
import { siteConfig } from "@/lib/configs/site.config";

const fontSans = FontSans({
  subsets: ["latin"],
  variable: "--font-sans",
});

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
};

export default async function DashboardLayout({
  children,
}: Readonly<{
  children: ReactNode;
}>) {
  const session = await auth();

  return (
    <html lang="en" suppressHydrationWarning>
      <body
        className={cn(
          "min-h-screen bg-background font-sans antialiased",
          fontSans.variable,
        )}
      >
        <NextTopLoader />
        <Providers session={session}>{children}</Providers>
      </body>
    </html>
  );
}
