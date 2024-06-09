"use client"

import Image from "next/image"
import Link from "next/link"
import { Product } from "@/features/product/product.type"
import { ColumnDef } from "@tanstack/react-table"
import { format } from "date-fns"
import parse from "html-react-parser"
import { match } from "ts-pattern"

import { Badge } from "@/components/ui/badge"
import {
  Tooltip,
  TooltipContent,
  TooltipTrigger,
} from "@/components/ui/tooltip"
import { Icons } from "@/components/custom/icons"

import { CellAction } from "./cell-action"

export const columns: ColumnDef<Product>[] = [
  {
    accessorKey: "imageUrl",
    header: "IMAGE",
    cell: (props) => {
      const imageUrl = props.getValue() as string
      return imageUrl ? (
        <Image src={imageUrl} alt="product" width={90} height={120} />
      ) : (
        <div className="flex h-20 w-20 items-center justify-center rounded-md bg-gray-100">
          <img
            loading="lazy"
            src="https://fakeimg.pl/90x120/?text=RookieShop"
            alt="product"
            width={90}
            height={120}
          />
        </div>
      )
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

      const badgeClass = match(status)
        .with("InStock", () => "bg-green-500 text-white")
        .with("OutOfStock", () => "bg-yellow-500 text-white")
        .otherwise(() => "bg-red-500 text-white")

      return (
        <Badge
          variant="secondary"
          className={`rounded-full px-2 py-1 text-xs font-semibold ${badgeClass}`}
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
      return description.length > 50 ? (
        <Tooltip>
          <TooltipTrigger asChild>
            <span>
              {parse(description.substring(0, 120))}
              <span className="text-blue-500">...</span>
            </span>
          </TooltipTrigger>
          <TooltipContent>
            <div className="w-80 p-4 text-sm">{parse(description)}</div>
          </TooltipContent>
        </Tooltip>
      ) : (
        parse(description)
      )
    },
  },
  {
    accessorKey: "quantity",
    header: "QUANTITY",
    cell: (props) => {
      const quantity = props.getValue() as number
      const MEDIUM_QTY = 20

      const className = match(quantity)
        .when(
          (quantity) => quantity >= MEDIUM_QTY,
          () => "text-green-500"
        )
        .when(
          (quantity) => quantity < MEDIUM_QTY,
          () => "text-yellow-500"
        )
        .otherwise(() => "text-red-500")

      return <span className={className}>{quantity}</span>
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
    header: "SALE",
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
                  className={`h-4 w-4 fill-current ${
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
    accessorKey: "totalReviews",
    header: "REVIEWS",
  },
  {
    accessorKey: "createdDate",
    header: "CREATED",
    cell: (props) =>
      props.getValue() && format(props.getValue() as Date, "dd/MM/yyyy"),
  },
  {
    accessorKey: "updatedDate",
    header: "UPDATED",
    cell: (props) => {
      const updatedDate = props.getValue() as Date
      return updatedDate ? (
        format(updatedDate, "dd/MM/yyyy")
      ) : (
        <Icons.minus className="text-gray-500" />
      )
    },
  },
  {
    id: "category",
    header: "CATEGORY",
    cell: (props) => {
      const { category } = props.row.original
      return (
        <Link href={`/dashboard/category/${category.id}`}>{category.name}</Link>
      )
    },
  },
  {
    id: "actions",
    cell: ({ row }) => <CellAction data={row.original} />,
  },
]
