"use client"

import { useState } from "react"
import { cn } from "@/lib/utils"
import { signIn } from "next-auth/react"
import { Icons } from "@/components/custom/icons"
import { buttonVariants } from "@/components/ui/button"

interface DuendeAuthButtonProps extends React.HTMLAttributes<HTMLDivElement> {}

export function DuendeAuthButton({
  className,
  ...props
}: DuendeAuthButtonProps) {
  const [isLoading] = useState<boolean>(false)
  const [isDuendeLoading, setIsDuendeLoading] = useState<boolean>(false)

  return (
    <div className={cn("grid gap-6", className)} {...props}>
      <button
        type="button"
        className={cn(buttonVariants({ variant: "outline" }))}
        onClick={() => {
          setIsDuendeLoading(true)
          signIn("duende-identity-server6")
        }}
        disabled={isLoading || isDuendeLoading}
      >
        {isDuendeLoading ? (
          <Icons.spinner className="mr-2 h-4 w-4 animate-spin" />
        ) : (
          <Icons.lock className="mr-2 h-4 w-4" />
        )}{" "}
        Sign in
      </button>
    </div>
  )
}
