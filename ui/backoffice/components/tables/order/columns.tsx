import { Order, PaymentMethod } from "@/features/order/order.type"
import { ColumnDef } from "@tanstack/react-table"

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
    accessorKey: "last4",
    header: "LAST4",
    cell: (props) => {
      const last4 = props.getValue() as string | null
      return last4 ? (
        <span className="text-blue-500">{last4}</span>
      ) : (
        <span>Not available</span>
      )
    },
  },
  {
    accessorKey: "brand",
    header: "CARD BRAND",
    cell: (props) => {
      const brand = props.getValue() as string | null
      return brand ? (
        <span className="text-blue-500">{brand}</span>
      ) : (
        <span>Not available</span>
      )
    },
  },
  {
    accessorKey: "chargeId",
		header: "CHARGE ID",
    cell: (props) => {
      const chargeId = props.getValue() as string | null
      return chargeId ? (
        <span className="text-blue-500">{chargeId}</span>
      ) : (
        <span>Not available</span>
      )
    },
	},
	{
		accessorKey: "paymentMethod",
		header: "PAYMENT METHOD",
		cell: (props) => {
			const paymentMethod = props.getValue() as PaymentMethod
			return paymentMethod === PaymentMethod.Card ? (
				<span className="text-blue-500">Card</span>
			) : (
				<span className="text-blue-500">Cash</span>
			)
		},
	},
  {
    id: "actions",
    cell: ({ row }) => <CellAction data={row.original} />,
  },
]
