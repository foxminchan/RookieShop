"use client"

import { Feedback } from "@/features/feedback/feedback.type"

import FilterTable from "@/components/custom/filter-table"

import { columns } from "./column"

export default function FeedbackTable({
  page,
  pageCount,
  data,
  totalRecords,
}: Readonly<{
  page: number
  pageCount: number
  data: Feedback[]
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
