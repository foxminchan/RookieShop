"use client"

import { cn } from "@/lib/utils"
import { useAuth } from "react-oidc-context"
import { Button } from "@/components/ui/button"
import { Icons } from "@/components/custom/icons"

interface DuendeAuthButtonProps extends React.HTMLAttributes<HTMLDivElement> {}

export function DuendeAuthButton({
  className,
  ...props
}: DuendeAuthButtonProps) {
  const auth = useAuth()

  return (
    <div className={cn("flex w-full gap-6", className)} {...props}>
      <Button
        className="w-full"
        variant="outline"
        onClick={() => void auth.signinRedirect()}
      >
        <Icons.lock className="mr-2 h-4 w-4" /> Sign in
      </Button>
    </div>
  )
}
