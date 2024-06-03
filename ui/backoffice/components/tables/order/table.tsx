"use client"

import { Order } from "@/features/order/order.type"

import FilterTable from "@/components/custom/filter-table"

import { columns } from "./columns"

export default function OrderTable({
  page,
  pageCount,
  data,
  totalRecords,
}: Readonly<{
  page: number
  pageCount: number
  data: Order[]
  totalRecords: number
}>) {
  return (
    <FilterTable
      searchKey=""
      pageNo={page}
      columns={columns}
      totalRecords={totalRecords}
      data={data}
      pageCount={pageCount}
    />
  )
}
