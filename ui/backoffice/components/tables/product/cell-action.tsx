"use client"

import { FC, useState } from "react"
import { usePathname, useRouter } from "next/navigation"
import { Product } from "@/features/product/product.type"
import useDeleteProduct from "@/features/product/useDeleteProduct"
import useListProducts from "@/features/product/useListProducts"
import { Edit, MoreHorizontal, Trash } from "lucide-react"

import { Button } from "@/components/ui/button"
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import { AlertModal } from "@/components/modals/alert-modal"

type CellActionProps = {
  data: Product
}

export const CellAction: FC<CellActionProps> = ({ data }) => {
  const [loading] = useState(false)
  const [open, setOpen] = useState(false)
  const router = useRouter()
  const pathname = usePathname()
  const { mutate: deleteProduct } = useDeleteProduct()
  const { refetch } = useListProducts()

  const productPath = `/dashboard/product/`

  const onConfirm = async () => {
    deleteProduct(data.id)
    setOpen(false)
    if (pathname !== productPath) router.replace(productPath)
    else await refetch()
  }

  return (
    <>
      <AlertModal
        isOpen={open}
        onClose={() => setOpen(false)}
        onConfirm={onConfirm}
        loading={loading}
      />
      <DropdownMenu modal={false}>
        <DropdownMenuTrigger asChild>
          <Button variant="ghost" className="h-8 w-8 p-0">
            <span className="sr-only">Open menu</span>
            <MoreHorizontal className="h-4 w-4" />
          </Button>
        </DropdownMenuTrigger>
        <DropdownMenuContent align="end">
          <DropdownMenuLabel>Actions</DropdownMenuLabel>
          <DropdownMenuItem
            onClick={() => router.push(`${productPath}${data.id}`)}
          >
            <Edit className="mr-2 h-4 w-4" /> Update
          </DropdownMenuItem>
          <DropdownMenuItem onClick={() => setOpen(true)}>
            <Trash className="mr-2 h-4 w-4" /> Delete
          </DropdownMenuItem>
        </DropdownMenuContent>
      </DropdownMenu>
    </>
  )
}
