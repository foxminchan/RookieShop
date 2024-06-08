"use client"

import { HTMLAttributes } from "react"
import { useRouter } from "next/navigation"

import { cn } from "@/lib/utils"
import { Button } from "@/components/ui/button"
import { Icons } from "@/components/custom/icons"

interface DuendeAuthButtonProps extends HTMLAttributes<HTMLDivElement> {}

export function DuendeAuthButton({
  className,
  ...props
}: DuendeAuthButtonProps) {
  const router = useRouter()

  return (
    <div className={cn("flex w-full gap-6", className)} {...props}>
      <Button
        className="w-full"
        variant="outline"
        onClick={() => router.push(`/bff/login?returnUrl=/dashboard`)}
      >
        <Icons.lock className="mr-2 h-4 w-4" /> Sign in
      </Button>
    </div>
  )
}
