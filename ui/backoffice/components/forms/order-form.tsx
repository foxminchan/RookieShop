"use client"

import { FC, useEffect } from "react"
import { useRouter } from "next/navigation"
import { OrderStatus, UpdateOrderRequest } from "@/features/order/order.type"
import useUpdateOrder from "@/features/order/useUpdateOrder"
import { zodResolver } from "@hookform/resolvers/zod"
import { useForm } from "react-hook-form"
import { z } from "zod"

import { orderSchema } from "@/lib/validations/order"

import { Button } from "../ui/button"
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "../ui/form"
import { Heading } from "../ui/heading"
import { Input } from "../ui/input"
import {
  Select,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "../ui/select"
import { Separator } from "../ui/separator"
import { useToast } from "../ui/use-toast"

type OrderFormValues = z.infer<typeof orderSchema>

type OrderFormProps = {
  initialData: UpdateOrderRequest
}

export const OrderForm: FC<OrderFormProps> = ({ initialData }) => {
  const router = useRouter()
  const { toast } = useToast()
  const {
    mutate: updateOrder,
    isSuccess: updateOrderSuccess,
    isPending: updateOrderPending,
  } = useUpdateOrder()

  const isDisabled = updateOrderSuccess || updateOrderPending

  const title = "Edit order"
  const description = "Edit an order."
  const toastMessage = "Order updated."
  const action = "Save changes"

  const defaultValues = initialData

  const form = useForm<OrderFormValues>({
    resolver: zodResolver(orderSchema),
    defaultValues,
  })

  const onSubmit = async (data: OrderFormValues) => {
    try {
      updateOrder(data)

      console.log("Order data: ", data)
    } catch (error: any) {
      toast({
        variant: "destructive",
        title: "Uh oh! Something went wrong.",
        description: "There was a problem with your request.",
      })
    }
  }

  useEffect(() => {
    if (updateOrderSuccess) {
      toast({
        title: "Success!",
        description: toastMessage,
      })

      setTimeout(() => {
        router.replace(`/dashboard/order`)
      }, 2000)
    }
  }, [updateOrderSuccess])

  return (
    <>
      <div className="flex items-center justify-between">
        <Heading title={title} description={description} />
      </div>
      <Separator />
      <Form {...form}>
        <form
          onSubmit={form.handleSubmit(onSubmit)}
          className="w-full space-y-8"
        >
          <div className="gap-8 md:grid md:grid-cols-2">
            <FormField
              control={form.control}
              name="id"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Name</FormLabel>
                  <FormControl>
                    <Input readOnly={true} placeholder="Order ID" {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name="orderStatus"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Status</FormLabel>
                  <Select
                    onValueChange={field.onChange}
                    defaultValue={field.value}
                  >
                    <FormControl>
                      <SelectTrigger>
                        <SelectValue placeholder="Select status" />
                      </SelectTrigger>
                    </FormControl>
                    <SelectContent>
                      <SelectGroup>
                        <SelectItem value={OrderStatus.Pending}>
                          Pending
                        </SelectItem>
                        <SelectItem value={OrderStatus.Shipping}>
                          Shipping
                        </SelectItem>
                        <SelectItem value={OrderStatus.Completed}>
                          Completed
                        </SelectItem>
                        <SelectItem value={OrderStatus.Cancelled}>
                          Cancelled
                        </SelectItem>
                      </SelectGroup>
                    </SelectContent>
                  </Select>
                  <FormMessage />
                </FormItem>
              )}
            />
          </div>
          <Button disabled={isDisabled} className="ml-auto" type="submit">
            {action}
          </Button>
        </form>
      </Form>
    </>
  )
}
