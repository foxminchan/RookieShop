import { DetailedHTMLProps, HTMLAttributes } from "react"

import { cn } from "@/lib/utils"

export function TypographyLarge({
  children,
  className,
  ...props
}: DetailedHTMLProps<HTMLAttributes<HTMLDivElement>, HTMLDivElement>) {
  return (
    <div className={cn("text-lg font-semibold", className)} {...props}>
      {children}
    </div>
  )
}
