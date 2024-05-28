import { cn } from "@/lib/utils"
import { DetailedHTMLProps, HTMLAttributes } from "react"

export function TypographyUList({
  children,
  className,
  ...props
}: DetailedHTMLProps<HTMLAttributes<HTMLUListElement>, HTMLUListElement>) {
  return (
    <ul className={cn("my-6 ml-6 list-disc [&>li]:mt-2", className)} {...props}>
      {children}
    </ul>
  )
}
