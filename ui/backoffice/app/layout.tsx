import "./globals.css";
import { auth } from "@/auth";
import { cn } from "@/lib/utils";
import { ReactNode } from "react";
import Providers from "./providers";
import type { Metadata } from "next";
import NextTopLoader from "nextjs-toploader";
import { Inter as FontSans } from "next/font/google";

const fontSans = FontSans({
  subsets: ["latin"],
  variable: "--font-sans",
});

export const metadata: Metadata = {
  title: "Backoffice",
  description: "An admin dashboard for managing your app",
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
