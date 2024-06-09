"use client"

import useListFeedbacks from "@/features/feedback/useListFeedbacks"
import { Separator } from "@radix-ui/react-dropdown-menu"

import { DEFAULT_PAGE_INDEX, DEFAULT_PAGE_SIZE } from "@/lib/constants/default"
import Breadcrumb from "@/components/ui/breadcrumb"
import { Heading } from "@/components/ui/heading"
import FeedbackTable from "@/components/tables/feedback/table"

const breadcrumbItems = [{ title: "Feedback", link: "/dashboard/feedback" }]

type paramsProps = {
  searchParams: {
    [key: string]: string | string[] | undefined
  }
}

export default function FeedbackPage({ searchParams }: Readonly<paramsProps>) {
  const page = Number(searchParams.page) || DEFAULT_PAGE_INDEX
  const pageLimit = Number(searchParams.limit) || DEFAULT_PAGE_SIZE

  const { data } = useListFeedbacks({
    pageIndex: page,
    pageSize: pageLimit,
  })

  const feedbacks = data?.feedbacks || []
  const totalFeedbacks = data?.pagedInfo.totalRecords ?? 0

  return (
    <div className="flex-1 space-y-4 p-4 pt-6 md:p-8">
      <Breadcrumb items={breadcrumbItems} />
      <div className="flex items-start justify-between">
        <Heading
          title={`Feedback (${totalFeedbacks})`}
          description="Manage feedback"
        />
      </div>
      <Separator />
      <FeedbackTable
        page={page}
        pageCount={data?.pagedInfo.totalPages ?? 0}
        data={feedbacks || []}
        totalRecords={totalFeedbacks || 0}
      />
    </div>
  )
}
