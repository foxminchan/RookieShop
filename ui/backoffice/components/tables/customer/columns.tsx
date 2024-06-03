"use client"

import Link from "next/link"
import { Customer } from "@/features/customer/customer.type"
import { ColumnDef } from "@tanstack/react-table"

import { cn } from "@/lib/utils"
import { Badge } from "@/components/ui/badge"

export const columns: ColumnDef<Customer>[] = [
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
