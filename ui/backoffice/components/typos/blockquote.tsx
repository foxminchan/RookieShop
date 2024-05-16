import { cn } from "@/lib/utils";
import { BlockquoteHTMLAttributes, DetailedHTMLProps } from "react";

export function TypographyBlockquote({
  children,
  className,
  ...props
}: DetailedHTMLProps<
  BlockquoteHTMLAttributes<HTMLQuoteElement>,
  HTMLQuoteElement
>) {
  return (
    <blockquote
      className={cn("mt-6 border-l-2 pl-6 italic", className)}
      {...props}
    >
      {children}
    </blockquote>
  );
}
