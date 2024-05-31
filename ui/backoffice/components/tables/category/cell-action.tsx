"use client"

import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import { FC, useState } from "react"
import { Button } from "@/components/ui/button"
import { usePathname, useRouter } from "next/navigation"
import { Edit, MoreHorizontal, Trash } from "lucide-react"
import { Category } from "@/features/category/category.type"
import { AlertModal } from "@/components/modals/alert-modal"
import useDeleteCategory from "@/features/category/useDeleteCategory"
import useListCategories from "@/features/category/useListCategories"

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

  const categoryPath = `/dashboard/category/`

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
            <MoreHorizontal className="h-4 w-4" />
          </Button>
        </DropdownMenuTrigger>
        <DropdownMenuContent align="end">
          <DropdownMenuLabel>Actions</DropdownMenuLabel>
          <DropdownMenuItem
            onClick={() => router.push(`${categoryPath}${data.id}`)}
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
