"use client"

import BreadCrumb from "@/components/ui/breadcrumb"
import { CategoryForm } from "@/components/forms/category-form"
import useGetCategory from "@/features/category/useGetCategory"

export default function EditCategory({ params }: { params: { id: string } }) {
  const breadcrumbItems = [
    { title: "Category", link: "/dashboard/category" },
    { title: "Edit", link: `/dashboard/category/${params.id}` },
  ]

  const { data } = useGetCategory(params.id)

  return (
    <div className="flex-1 space-y-4 p-8">
      <BreadCrumb items={breadcrumbItems} />
      <CategoryForm initialData={data || null} key={null} />
    </div>
  )
}
