"use client"

import useListOrders from "@/features/order/useListOrders"

import { DEFAULT_PAGE_INDEX, DEFAULT_PAGE_SIZE } from "@/lib/constants/default"
import Breadcrumb from "@/components/ui/breadcrumb"
import { Heading } from "@/components/ui/heading"
import { Separator } from "@/components/ui/separator"
import OrderTable from "@/components/tables/order/table"

const breadcrumbItems = [{ title: "Order", link: "/dashboard/order" }]

type paramsProps = {
  searchParams: {
    [key: string]: string | string[] | undefined
  }
}

export default function OrderPage({ searchParams }: Readonly<paramsProps>) {
  const page = Number(searchParams.page) || DEFAULT_PAGE_INDEX
  const pageLimit = Number(searchParams.limit) || DEFAULT_PAGE_SIZE

  const { data } = useListOrders({
    pageIndex: page,
    pageSize: pageLimit,
  })

  const orders = data?.orders || []
  const totalOrders = data?.pagedInfo.totalRecords ?? 0

  return (
    <div className="flex-1 space-y-4 p-4 pt-6 md:p-8">
      <Breadcrumb items={breadcrumbItems} />
      <div className="flex items-start justify-between">
        <Heading title={`Order (${totalOrders})`} description="Manage order" />
      </div>
      <Separator />
      <OrderTable
        page={page}
        pageCount={data?.pagedInfo.totalPages ?? 0}
        data={orders || []}
        totalRecords={totalOrders || 0}
      />
    </div>
  )
}
