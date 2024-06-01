"use client"

import { Product } from "@/features/product/product.type"

import FilterTable from "@/components/custom/filter-table"

import { columns } from "./columns"

export default function ProductTable({
  page,
  pageCount,
  data,
  totalRecords,
}: Readonly<{
  page: number
  pageCount: number
  data: Product[]
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
