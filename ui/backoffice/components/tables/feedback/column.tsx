"use client"

import Link from "next/link"
import { Feedback } from "@/features/feedback/feedback.type"
import { ColumnDef } from "@tanstack/react-table"
import { format } from "date-fns"

import { Checkbox } from "@/components/ui/checkbox"

import { CellAction } from "./cell-action"

export const columns: ColumnDef<Feedback>[] = [
  {
    id: "select",
    header: ({ table }) => (
      <Checkbox
        checked={table.getIsAllPageRowsSelected()}
        onCheckedChange={(value) => table.toggleAllPageRowsSelected(!!value)}
        aria-label="Select all"
      />
    ),
    cell: ({ row }) => (
      <Checkbox
        checked={row.getIsSelected()}
        onCheckedChange={(value) => row.toggleSelected(!!value)}
        aria-label="Select row"
      />
    ),
    enableSorting: false,
    enableHiding: false,
  },
  {
    accessorKey: "customer.customerName",
    header: "CUSTOMER",
  },
  {
    accessorKey: "content",
    header: "CONTENT",
  },
  {
    accessorKey: "rating",
    header: "RATING",
    cell: (props) => {
      const rating = props.getValue() as number
      return (
        <div className="flex items-center">
          <div className="flex space-x-1">
            {Array.from({ length: 5 }).map((_, index) => {
              const starId = `star-${index}`
              return (
                <svg
                  key={starId}
                  className={`w-4 h-4 fill-current ${
                    index < rating ? "text-yellow-500" : "text-gray-300"
                  }`}
                  xmlns="http://www.w3.org/2000/svg"
                  viewBox="0 0 24 24"
                >
                  <path d="M12 2l2.121 6.485L20 9.757l-5.485 3.758L16 20l-4-2.5L8 20l1.485-6.242L4 9.757l5.879-1.272z" />
                </svg>
              )
            })}
          </div>
        </div>
      )
    },
  },
  {
    accessorKey: "updatedDate",
    header: "DATE",
    cell: (props) =>
      props.getValue() && format(props.getValue() as Date, "dd/MM/yyyy"),
  },
  {
    accessorKey: "productId",
    header: "Product",
    cell: (props) => {
      const productId = props.getValue() as string
      return <Link href={`/dashboard/product/${productId}`}>{productId}</Link>
    },
  },
  {
    id: "actions",
    cell: ({ row }) => <CellAction data={row.original} />,
  },
]
