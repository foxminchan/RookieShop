import { DetailedHTMLProps, HTMLAttributes } from "react"

import { cn } from "@/lib/utils"

export function TypographyP({
  children,
  className,
  ...props
}: DetailedHTMLProps<
  HTMLAttributes<HTMLParagraphElement>,
  HTMLParagraphElement
>) {
  return (
    <p
      className={cn("leading-7 [&:not(:first-child)]:mt-6", className)}
      {...props}
    >
      {children}
    </p>
  )
}
