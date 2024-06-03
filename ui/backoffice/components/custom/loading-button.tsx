import React from "react"

import { Button, ButtonProps } from "../ui/button"
import { Icons } from "./icons"

export interface LoadingButtonProps extends ButtonProps {
  isLoading?: boolean
  loadingHolder?: React.ReactNode
}

export default function LoadingButton({
  isLoading = false,
  loadingHolder = (
    <>
      <Icons.spinner className="mr-2 h-4 w-4 animate-spin" />
      {"Please wait"}
    </>
  ),
  children,
  className,
  ...props
}: Readonly<LoadingButtonProps>) {
  return (
    <Button disabled={isLoading} {...props}>
      {isLoading ? loadingHolder : children}
    </Button>
  )
}
