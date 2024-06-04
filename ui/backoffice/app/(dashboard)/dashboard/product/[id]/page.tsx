"use client"

import useGetProduct from "@/features/product/useGetProduct"

import BreadCrumb from "@/components/ui/breadcrumb"
import { ProductForm } from "@/components/forms/product-form"

export default function EditProduct({
  params,
}: Readonly<{ params: { id: string } }>) {
  const breadcrumbItems = [
    { title: "Product", link: "/dashboard/product" },
    { title: "Edit", link: `/dashboard/product/${params.id}` },
  ]

  const { data } = useGetProduct(params.id)

  return (
    <div className="flex-1 space-y-4 p-8">
      <BreadCrumb items={breadcrumbItems} />
      {data && (
        <ProductForm initialData={data} currentProductImages={data.imageUrl} />
      )}
    </div>
  )
}
