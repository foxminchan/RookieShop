import { cn } from "@/lib/utils"
import { DetailedHTMLProps, HTMLAttributes } from "react"

export function TypographyMuted({
  children,
  className,
  ...props
}: DetailedHTMLProps<
  HTMLAttributes<HTMLParagraphElement>,
  HTMLParagraphElement
>) {
  return (
    <p className={cn("text-sm text-muted-foreground", className)} {...props}>
      {children}
    </p>
  )
}
