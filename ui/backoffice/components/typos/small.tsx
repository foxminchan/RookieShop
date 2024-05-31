import { DetailedHTMLProps, HTMLAttributes } from "react"

import { cn } from "@/lib/utils"

export function TypographySmall({
  children,
  className,
  ...props
}: DetailedHTMLProps<HTMLAttributes<HTMLElement>, HTMLElement>) {
  return (
    <small
      className={cn("text-sm font-medium leading-none", className)}
      {...props}
    >
      {children}
    </small>
  )
}
