"use client"

import { Category } from "@/features/category/category.type"
import { ColumnDef } from "@tanstack/react-table"
import parse from "html-react-parser"

import { CellAction } from "./cell-action"

export const columns: ColumnDef<Category>[] = [
  {
    accessorKey: "name",
    header: "NAME",
  },
  {
    accessorKey: "description",
    header: "DESCRIPTION",
    cell: (props) => {
      const description = props.getValue() as string
      return parse(description)
    },
  },
  {
    id: "actions",
    cell: ({ row }) => <CellAction data={row.original} />,
  },
]
