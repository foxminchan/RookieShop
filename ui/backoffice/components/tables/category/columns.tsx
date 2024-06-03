"use client"

import { Category } from "@/features/category/category.type"
import { ColumnDef } from "@tanstack/react-table"

import { CellAction } from "./cell-action"

export const columns: ColumnDef<Category>[] = [
  {
    accessorKey: "name",
    header: "NAME",
  },
  {
    accessorKey: "description",
    header: "DESCRIPTION",
  },
  {
    id: "actions",
    cell: ({ row }) => <CellAction data={row.original} />,
  },
]
