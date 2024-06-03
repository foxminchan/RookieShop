import BreadCrumb from "@/components/ui/breadcrumb"
import { ProductForm } from "@/components/forms/product-form"

export default function AddProduct() {
  const breadcrumbItems = [
    { title: "Product", link: "/dashboard/product" },
    { title: "Create", link: "/dashboard/product/new" },
  ]

  return (
    <div className="flex-1 space-y-4 p-8">
      <BreadCrumb items={breadcrumbItems} />
      <ProductForm initialData={null} key={null} />
    </div>
  )
}
