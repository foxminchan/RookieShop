"use client"

import Link from "next/link"
import useListProducts from "@/features/product/useListProducts"

import {
  DEFAULT_ORDER_BY,
  DEFAULT_PAGE_INDEX,
  DEFAULT_PAGE_SIZE,
} from "@/lib/constants/default"
import { cn } from "@/lib/utils"
import Breadcrumb from "@/components/ui/breadcrumb"
import { buttonVariants } from "@/components/ui/button"
import { Heading } from "@/components/ui/heading"
import { Separator } from "@/components/ui/separator"
import { Icons } from "@/components/custom/icons"
import ProductTable from "@/components/tables/product/table"

const breadcrumbItems = [{ title: "Product", link: "/dashboard/product" }]

type paramsProps = {
  searchParams: {
    [key: string]: string | string[] | undefined | boolean
  }
}

export default function ProductPage({ searchParams }: Readonly<paramsProps>) {
  const page = Number(searchParams.page) || DEFAULT_PAGE_INDEX
  const pageLimit = Number(searchParams.limit) || DEFAULT_PAGE_SIZE
  const name = (searchParams.search as string) || undefined
  const orderBy = (searchParams.orderBy as string) || DEFAULT_ORDER_BY
  const isDescending = (searchParams.isDescending as boolean) || false

  const { data } = useListProducts({
    pageIndex: page,
    pageSize: pageLimit,
    search: name,
    orderBy: orderBy,
    isDescending: isDescending,
  })

  const products = data?.products || []
  const totalProducts = data?.pagedInfo.totalRecords ?? 0

  return (
    <div className="flex-1 space-y-4 p-4 pt-6 md:p-8">
      <Breadcrumb items={breadcrumbItems} />
      <div className="flex items-start justify-between">
        <Heading
          title={`Products (${totalProducts})`}
          description="Manage products"
        />
        <Link
          href={"/dashboard/product/new"}
          className={cn(buttonVariants({ variant: "default" }))}
        >
          <Icons.add className="mr-2 h-4 w-4" /> Add New
        </Link>
      </div>
      <Separator />
      <ProductTable
        page={page}
        pageCount={data?.pagedInfo.totalPages ?? 0}
        data={products || []}
        totalRecords={totalProducts || 0}
      />
    </div>
  )
}
