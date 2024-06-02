"use client"

import Link from "next/link"
import { Customer } from "@/features/customer/customer.type"
import { ColumnDef } from "@tanstack/react-table"

import { cn } from "@/lib/utils"
import { Badge } from "@/components/ui/badge"
import { Checkbox } from "@/components/ui/checkbox"

export const columns: ColumnDef<Customer>[] = [
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
    accessorKey: "name",
    header: "NAME",
  },
  {
    accessorKey: "email",
    header: "EMAIL",
    cell: (props) => {
      const email = props.getValue() as string
      return <Link href={`mailto:${email}`}>{email}</Link>
    },
  },
  {
    accessorKey: "phone",
    header: "PHONE",
    cell: (props) => {
      const phone = props.getValue() as string
      return <Link href={`tel:${phone}`}>{phone}</Link>
    },
  },
  {
    accessorKey: "gender",
    header: "GENDER",
    cell: (props) => {
      const gender = props.getValue() as string
      return (
        <Badge
          className={cn(
            "capitalize",
            gender === "Male" ? "bg-blue-500" : "bg-pink-500"
          )}
          variant="secondary"
        >
          {gender}
        </Badge>
      )
    },
  },
]
