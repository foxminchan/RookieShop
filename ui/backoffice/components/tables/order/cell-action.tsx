"use client"

import { FC } from "react"
import { useRouter } from "next/navigation"
import { Order } from "@/features/order/order.type"

import { Button } from "@/components/ui/button"
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import { Icons } from "@/components/custom/icons"

type CellActionProps = {
  data: Order
}

export const CellAction: FC<CellActionProps> = ({ data }) => {
  const router = useRouter()

  const orderPath = `/dashboard/order/`

  return (
    <DropdownMenu modal={false}>
      <DropdownMenuTrigger asChild>
        <Button variant="ghost" className="h-8 w-8 p-0">
          <span className="sr-only">Open menu</span>
          <Icons.more className="h-4 w-4" />
        </Button>
      </DropdownMenuTrigger>
      <DropdownMenuContent align="end">
        <DropdownMenuLabel>Actions</DropdownMenuLabel>
        <DropdownMenuItem onClick={() => router.push(`${orderPath}${data.id}`)}>
          <Icons.edit className="mr-2 h-4 w-4" /> Update
        </DropdownMenuItem>
      </DropdownMenuContent>
    </DropdownMenu>
  )
}
