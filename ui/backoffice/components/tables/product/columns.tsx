"use client"

import { Product } from "@/features/product/product.type"
import { ColumnDef } from "@tanstack/react-table"

import { Checkbox } from "@/components/ui/checkbox"

import { CellAction } from "./cell-action"

export const columns: ColumnDef<Product>[] = [
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
    id: "image",
    accessorKey: "imageUrl",
    header: "IMAGE",
  },
  {
    accessorKey: "name",
    header: "NAME",
    enableSorting: true,
  },
  {
    accessorKey: "status",
    header: "STATUS",
  },
  {
    accessorKey: "description",
    header: "DESCRIPTION",
  },
  {
    accessorKey: "quantity",
    header: "QUANTITY",
  },
  {
    accessorKey: "price",
    header: "PRICE",
  },
  {
    accessorKey: "priceSale",
    header: "PRICE SALE",
  },
  {
    accessorKey: "averageRating",
    header: "AVERAGE RATING",
  },
  {
    accessorKey: "totalRating",
    header: "TOTAL RATING",
  },
  {
    id: "actions",
    cell: ({ row }) => <CellAction data={row.original} />,
  },
]
