"use client"

import { columns } from "./columns"
import FilterTable from "@/components/custom/filter-table"
import { Category } from "@/features/category/category.type"

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
