import { CategoryForm } from "@/components/forms/category-form"
import BreadCrumb from "@/components/ui/breadcrumb"

export default function AddCategory() {
  const breadcrumbItems = [
    { title: "Category", link: "/dashboard/category" },
    { title: "Create", link: "/dashboard/category/new" },
  ]

  return (
    <div className="flex-1 space-y-4 p-8">
      <BreadCrumb items={breadcrumbItems} />
      <CategoryForm initialData={null} key={null} />
    </div>
  )
}
