"use client"

import { Customer } from "@/features/customer/customer.type"

import FilterTable from "@/components/custom/filter-table"

import { columns } from "./columns"

export default function CustomerTable({
  page,
  pageCount,
  data,
  totalRecords,
}: Readonly<{
  page: number
  pageCount: number
  data: Customer[]
  totalRecords: number
}>) {
  return (
    <FilterTable
      searchKey="name"
      pageNo={page}
      columns={columns}
      totalRecords={totalRecords}
      data={data}
      pageCount={pageCount}
    />
  )
}
