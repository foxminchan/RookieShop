"use client"

import Image from "next/image"
import { Order, PaymentMethod } from "@/features/order/order.type"
import { ColumnDef } from "@tanstack/react-table"
import { format } from "date-fns"

import { Badge } from "@/components/ui/badge"
import { Checkbox } from "@/components/ui/checkbox"

import { CellAction } from "./cell-action"

export const columns: ColumnDef<Order>[] = [
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
    accessorKey: "id",
    header: "ORDER ID",
  },
  {
    id: "card",
    header: "CARD",
    cell: (props) => {
      const { last4, brand, chargeId } = props.row.original
      if (last4 === null && brand === null && chargeId === null) {
        return <span className="text-gray-500">No data</span>
      } else {
        return (
          <div>
            <span>
              <strong className="text-yellow-500">Last4:</strong> {last4}
            </span>
            <br />
            <span>
              <strong className="text-yellow-500">Brand:</strong> {brand}
            </span>
            <br />
            <span>
              <strong className="text-yellow-500">Charge ID:</strong> {chargeId}
            </span>
          </div>
        )
      }
    },
  },
  {
    accessorKey: "paymentMethod",
    header: "METHOD",
    cell: (props) => {
      const paymentMethod = props.getValue() as PaymentMethod
      return paymentMethod === PaymentMethod.Card ? (
        <Image src="/payment/stripe.png" alt="card" width={30} height={30} />
      ) : (
        <Image src="/payment/dollar.png" alt="cash" width={30} height={30} />
      )
    },
  },
  {
    id: "address",
    header: "ADDRESS",
    cell: (props) => {
      const { street, city, province } = props.row.original
      return (
        <span>
          {street}, {city}, {province}
        </span>
      )
    },
  },
  {
    accessorKey: "orderStatus",
    header: "STATUS",
    cell: (props) => {
      const status = props.getValue() as string
      let badgeClass = ""
      switch (status) {
        case "Pending":
          badgeClass = "bg-yellow-700 text-white"
          break
        case "Shipping":
          badgeClass = "bg-blue-700 text-white"
          break
        case "Completed":
          badgeClass = "bg-green-700 text-white"
          break
        case "Cancelled":
          badgeClass = "bg-red-700 text-white"
          break
        default:
          badgeClass = "bg-gray-700 text-white"
          break
      }
      return (
        <Badge
          variant="secondary"
          className={`px-2 py-1 text-xs font-semibold rounded-full ${badgeClass}`}
        >
          {status}
        </Badge>
      )
    },
  },
  {
    accessorKey: "totalPrice",
    header: "TOTAL",
    cell: (props) => {
      const price = props.getValue() as number
      return new Intl.NumberFormat("en-US", {
        style: "currency",
        currency: "USD",
      }).format(price)
    },
  },
  {
    accessorKey: "createdDate",
    header: "DATE",
    cell: (props) =>
      props.getValue() && format(props.getValue() as Date, "dd/MM/yyyy"),
  },
  {
    id: "actions",
    cell: ({ row }) => <CellAction data={row.original} />,
  },
]
