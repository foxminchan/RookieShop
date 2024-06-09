import { Metadata } from "next"
import Link from "next/link"

import { DuendeAuthButton } from "@/components/custom/duende-auth-button"
import { Icons } from "@/components/custom/icons"

export const metadata: Metadata = {
  title: "Login",
  description: "Login to your account",
}

export default function LoginPage() {
  return (
    <div className="container flex h-screen w-screen flex-col items-center justify-center">
      <div className="mx-auto flex w-full flex-col justify-center space-y-6 sm:w-[350px]">
        <div className="flex flex-col space-y-2 text-center">
          <Icons.logo className="mx-auto h-6 w-6" />
          <h1 className="text-2xl font-semibold tracking-tight">
            Welcome back
          </h1>
          <p className="text-sm text-muted-foreground">
            Sign in to your account
          </p>
        </div>
        <DuendeAuthButton />
        <p className="text-center text-sm text-muted-foreground">
          Power by{" "}
          <Link
            href="https://duendesoftware.com/"
            className="hover:text-brand underline underline-offset-4"
          >
            Duende
          </Link>
        </p>
      </div>
    </div>
  )
}
