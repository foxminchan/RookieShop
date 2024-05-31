import { DetailedHTMLProps, HTMLAttributes } from "react"

import { cn } from "@/lib/utils"

export function TypographyH3({
  children,
  className,
  ...props
}: DetailedHTMLProps<HTMLAttributes<HTMLHeadingElement>, HTMLHeadingElement>) {
  return (
    <h3
      className={cn(
        "scroll-m-20 text-2xl font-semibold tracking-tight",
        className
      )}
      {...props}
    >
      {children}
    </h3>
  )
}
