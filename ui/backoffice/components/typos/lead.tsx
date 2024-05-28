import { cn } from "@/lib/utils"
import { DetailedHTMLProps, HTMLAttributes } from "react"

export function TypographyLead({
  children,
  className,
  ...props
}: DetailedHTMLProps<
  HTMLAttributes<HTMLParagraphElement>,
  HTMLParagraphElement
>) {
  return (
    <p className={cn("text-xl text-muted-foreground", className)} {...props}>
      {children}
    </p>
  )
}
