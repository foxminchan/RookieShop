"use client"

import { OrderItem } from "@/features/order/order.type"

import FilterTable from "@/components/custom/filter-table"

import { columns } from "./columns"

export default function OrderDetailTable({
  data,
}: Readonly<{
  data: OrderItem[]
}>) {
  return (
    <FilterTable
      searchKey=""
      pageNo={0}
      columns={columns}
      totalRecords={0}
      data={data}
      pageCount={0}
    />
  )
}
