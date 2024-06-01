"use client"

import Link from "next/link"
import useListCategories from "@/features/category/useListCategories"
import { Plus } from "lucide-react"

import { cn } from "@/lib/utils"
import Breadcrumb from "@/components/ui/breadcrumb"
import { buttonVariants } from "@/components/ui/button"
import { Heading } from "@/components/ui/heading"
import { Separator } from "@/components/ui/separator"
import CategoryTable from "@/components/tables/category/table"

const breadcrumbItems = [{ title: "Category", link: "/dashboard/category" }]

type paramsProps = {
  searchParams: {
    [key: string]: string | string[] | undefined
  }
}

export default function CatgoryPage({ searchParams }: Readonly<paramsProps>) {
  const page = Number(searchParams.page) || 1
  const pageLimit = Number(searchParams.limit) || 20
  const name = (searchParams.search as string) || null

  const { data } = useListCategories({
    pageIndex: page,
    pageSize: pageLimit,
    search: name,
  })

  const categories = data?.categories || []
  const totalCategories = data?.pagedInfo.totalRecords ?? 0

  return (
    <div className="flex-1 space-y-4  p-4 pt-6 md:p-8">
      <Breadcrumb items={breadcrumbItems} />
      <div className="flex items-start justify-between">
        <Heading
          title={`Category (${totalCategories})`}
          description="Manage categories"
        />

        <Link
          href={"/dashboard/category/new"}
          className={cn(buttonVariants({ variant: "default" }))}
        >
          <Plus className="mr-2 h-4 w-4" /> Add New
        </Link>
      </div>
      <Separator />
      <CategoryTable
        page={page}
        pageCount={data?.pagedInfo.totalPages ?? 0}
        data={categories || []}
        totalRecords={totalCategories || 0}
      />
    </div>
  )
}
