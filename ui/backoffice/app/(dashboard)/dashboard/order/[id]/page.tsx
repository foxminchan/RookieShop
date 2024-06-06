"use client"

import useGetOrder from "@/features/order/useGetOrder"
import { Separator } from "@radix-ui/react-dropdown-menu"

import BreadCrumb from "@/components/ui/breadcrumb"
import { Heading } from "@/components/ui/heading"
import { OrderForm } from "@/components/forms/order-form"
import OrderDetailTable from "@/components/tables/order_details/table"

export default function EditOrder({
  params,
}: Readonly<{ params: { id: string } }>) {
  const breadcrumbItems = [
    { title: "Order", link: "/dashboard/order" },
    { title: "Edit", link: `/dashboard/order/${params.id}` },
  ]

  const { data: GetOrder } = useGetOrder(params.id)

  console.log(GetOrder)

  return (
    <div className="flex-1 space-y-4 p-8">
      <BreadCrumb items={breadcrumbItems} />
      {GetOrder && (
        <OrderForm
          initialData={{
            id: GetOrder.id,
            orderStatus: GetOrder.orderStatus,
          }}
        />
      )}
      <Separator />
      <div className="flex items-start justify-between">
        <Heading title={`Order detail`} description="Manage order item" />
      </div>
      <OrderDetailTable data={GetOrder?.items || []} />
    </div>
  )
}
