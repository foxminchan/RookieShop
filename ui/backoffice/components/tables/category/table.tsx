"use client"

import { Category } from "@/features/category/category.type"

import FilterTable from "@/components/custom/filter-table"

import { columns } from "./columns"

export default function CategoryTable({
  page,
  pageCount,
  data,
  totalRecords,
}: Readonly<{
  page: number
  pageCount: number
  data: Category[]
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
