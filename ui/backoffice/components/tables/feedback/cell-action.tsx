"use client"

import { FC, useState } from "react"
import { usePathname, useRouter } from "next/navigation"
import { Feedback } from "@/features/feedback/feedback.type"
import useDeleteFeedback from "@/features/feedback/useDeleteFeedback"
import useListFeedbacks from "@/features/feedback/useListFeedbacks"
import { MoreHorizontal, Trash } from "lucide-react"

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
  data: Feedback
}

export const CellAction: FC<CellActionProps> = ({ data }) => {
  const [loading] = useState(false)
  const [open, setOpen] = useState(false)
  const router = useRouter()
  const pathname = usePathname()
  const { mutate: deleteFeedback } = useDeleteFeedback()
  const { refetch } = useListFeedbacks()

  const categoryPath = `/dashboard/feedback`

  const onConfirm = async () => {
    deleteFeedback(data.id)
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
          <DropdownMenuItem onClick={() => setOpen(true)}>
            <Trash className="mr-2 h-4 w-4" /> Delete
          </DropdownMenuItem>
        </DropdownMenuContent>
      </DropdownMenu>
    </>
  )
}
