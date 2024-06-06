"use client"

import { OrderItem } from "@/features/order/order.type"
import { ColumnDef } from "@tanstack/react-table"

export const columns: ColumnDef<OrderItem>[] = [
  {
    accessorKey: "id",
    header: "PRODUCT ID",
  },
  {
    accessorKey: "price",
    header: "PRICE",
    cell: (props) => {
      const price = props.getValue() as number
      return new Intl.NumberFormat("en-US", {
        style: "currency",
        currency: "USD",
      }).format(price)
    },
  },
  {
    accessorKey: "quantity",
    header: "QUANTITY",
  },
  {
    header: "TOTAL",
    cell: (props) => {
      const { price, quantity } = props.row.original
      return new Intl.NumberFormat("en-US", {
        style: "currency",
        currency: "USD",
      }).format(price * quantity)
    },
  },
]
