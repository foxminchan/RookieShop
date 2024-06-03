"use client"

import Image from "next/image"
import { Product } from "@/features/product/product.type"
import { ColumnDef } from "@tanstack/react-table"

import { Badge } from "@/components/ui/badge"
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
    accessorKey: "imageUrl",
    header: "IMAGE",
    cell: (props) => {
      const imageUrl = props.getValue() as string
      return <Image src={imageUrl} alt="product" width={50} height={50} />
    },
  },
  {
    accessorKey: "name",
    header: "NAME",
    enableSorting: true,
  },
  {
    accessorKey: "status",
    header: "STATUS",
    cell: (props) => {
      const status = props.getValue() as string
      return (
        <Badge
          variant="secondary"
          className={`px-2 py-1 text-xs font-semibold rounded-full ${
            status === "InStock"
              ? "bg-green-500 text-white"
              : status === "OutOfStock"
                ? "bg-yellow-500 text-white"
                : "bg-red-500 text-white"
          }`}
        >
          {status}
        </Badge>
      )
    },
  },
  {
    accessorKey: "description",
    header: "DESCRIPTION",
    cell: (props) => {
      const description = props.getValue() as string
      return description.length > 50
        ? `${description.slice(0, 50)}...`
        : description
    },
  },
  {
    accessorKey: "quantity",
    header: "QUANTITY",
    cell: (props) => {
      const quantity = props.getValue() as number
      return quantity > 0 ? (
        <span className="text-green-500">{quantity}</span>
      ) : (
        <span className="text-red-500">{quantity}</span>
      )
    },
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
    accessorKey: "priceSale",
    header: "PRICE SALE",
    cell: (props) => {
      const priceSale = props.getValue() as number
      return (
        <span className="text-red-500">
          {new Intl.NumberFormat("en-US", {
            style: "currency",
            currency: "USD",
          }).format(priceSale)}
        </span>
      )
    },
  },
  {
    accessorKey: "averageRating",
    header: "AVERAGE RATING",
    cell: (props) => {
      const rating = props.getValue() as number
      return (
        <div className="flex items-center">
          <div className="flex space-x-1">
            {Array.from({ length: 5 }).map((_, index) => (
              <svg
                key={index}
                className={`w-4 h-4 fill-current ${
                  index < rating ? "text-yellow-500" : "text-gray-300"
                }`}
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 24 24"
              >
                <path d="M12 2l2.121 6.485L20 9.757l-5.485 3.758L16 20l-4-2.5L8 20l1.485-6.242L4 9.757l5.879-1.272z" />
              </svg>
            ))}
          </div>
        </div>
      )
    },
  },
  {
    accessorKey: "totalReviews",
    header: "TOTAL RATING",
  },
  {
    id: "actions",
    cell: ({ row }) => <CellAction data={row.original} />,
  },
]
