"use client"

import { FC, useState } from "react"
import { usePathname, useRouter } from "next/navigation"
import { Category } from "@/features/category/category.type"
import useDeleteCategory from "@/features/category/useDeleteCategory"
import useListCategories from "@/features/category/useListCategories"

import { Button } from "@/components/ui/button"
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import { Icons } from "@/components/custom/icons"
import { AlertModal } from "@/components/modals/alert-modal"

type CellActionProps = {
  data: Category
}

export const CellAction: FC<CellActionProps> = ({ data }) => {
  const [loading] = useState(false)
  const [open, setOpen] = useState(false)
  const router = useRouter()
  const pathname = usePathname()
  const { mutate: deleteCategory } = useDeleteCategory()
  const { refetch } = useListCategories()

  const categoryPath = `/dashboard/category`

  const onConfirm = async () => {
    deleteCategory(data.id)
    setOpen(false)
    if (pathname !== categoryPath) router.replace(categoryPath)
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
            <Icons.more className="h-4 w-4" />
          </Button>
        </DropdownMenuTrigger>
        <DropdownMenuContent align="end">
          <DropdownMenuLabel>Actions</DropdownMenuLabel>
          <DropdownMenuItem
            onClick={() => router.push(`${categoryPath}/${data.id}`)}
          >
            <Icons.edit className="mr-2 h-4 w-4" /> Update
          </DropdownMenuItem>
          <DropdownMenuItem onClick={() => setOpen(true)}>
            <Icons.trash className="mr-2 h-4 w-4" /> Delete
          </DropdownMenuItem>
        </DropdownMenuContent>
      </DropdownMenu>
    </>
  )
}
