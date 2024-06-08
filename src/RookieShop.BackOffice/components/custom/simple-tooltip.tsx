import React from "react"
import { TooltipProps, TooltipTriggerProps } from "@radix-ui/react-tooltip"

import { Tooltip, TooltipContent, TooltipTrigger } from "../ui/tooltip"

interface SimpleTooltipProps extends TooltipTriggerProps {
  tooltipContent: React.ReactNode
  parentProps?: TooltipProps
  children: React.ReactNode
}

export default function SimpleTooltip({
  children,
  tooltipContent,
  parentProps,
  ...props
}: Readonly<SimpleTooltipProps>) {
  return (
    <Tooltip {...parentProps}>
      <TooltipTrigger {...props}>{children}</TooltipTrigger>
      <TooltipContent>{tooltipContent}</TooltipContent>
    </Tooltip>
  )
}
