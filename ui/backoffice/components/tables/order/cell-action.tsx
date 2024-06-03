"use client"

import { FC } from "react"
import { useRouter } from "next/navigation"
import { Order } from "@/features/order/order.type"
import { Edit, MoreHorizontal } from "lucide-react"

import { Button } from "@/components/ui/button"
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"

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
          <MoreHorizontal className="h-4 w-4" />
        </Button>
      </DropdownMenuTrigger>
      <DropdownMenuContent align="end">
        <DropdownMenuLabel>Actions</DropdownMenuLabel>
        <DropdownMenuItem onClick={() => router.push(`${orderPath}${data.id}`)}>
          <Edit className="mr-2 h-4 w-4" /> Update
        </DropdownMenuItem>
      </DropdownMenuContent>
    </DropdownMenu>
  )
}
