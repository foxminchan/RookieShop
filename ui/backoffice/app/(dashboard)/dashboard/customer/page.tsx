"use client"

import useListCustomers from "@/features/customer/useListCustomers"

import Breadcrumb from "@/components/ui/breadcrumb"
import { Heading } from "@/components/ui/heading"
import { Separator } from "@/components/ui/separator"
import CustomerTable from "@/components/tables/customer/table"

const breadcrumbItems = [{ title: "Customer", link: "/dashboard/customer" }]

type paramsProps = {
  searchParams: {
    [key: string]: string | string[] | undefined
  }
}

export default function CustomerPage({ searchParams }: Readonly<paramsProps>) {
  const page = Number(searchParams.page) || 1
  const pageLimit = Number(searchParams.limit) || 20
  const name = (searchParams.search as string) || null

  const { data } = useListCustomers({
    pageIndex: page,
    pageSize: pageLimit,
    search: name,
  })

  console.log(data)

  const customers = data?.customers || []
  const totalCustomers = data?.pagedInfo.totalRecords ?? 0

  return (
    <div className="flex-1 space-y-4  p-4 pt-6 md:p-8">
      <Breadcrumb items={breadcrumbItems} />
      <div className="flex items-start justify-between">
        <Heading
          title={`Customer (${totalCustomers})`}
          description="Manage customers"
        />
      </div>
      <Separator />
      <CustomerTable
        page={page}
        pageCount={data?.pagedInfo.totalPages ?? 0}
        data={customers || []}
        totalRecords={totalCustomers || 0}
      />
    </div>
  )
}
