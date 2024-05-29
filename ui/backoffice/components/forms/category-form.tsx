"use client"

import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "../ui/form"
import * as z from "zod"
import { Input } from "../ui/input"
import { FC, useState } from "react"
import { Trash } from "lucide-react"
import { Button } from "../ui/button"
import { Heading } from "../ui/heading"
import { useForm } from "react-hook-form"
import { useToast } from "../ui/use-toast"
import { Separator } from "../ui/separator"
import { zodResolver } from "@hookform/resolvers/zod"
import { useParams, useRouter } from "next/navigation"
import { categorySchema } from "@/lib/validations/category"
import useCreateCategory from "@/features/category/useCreateCategory"
import useUpdateCategory from "@/features/category/useUpdateCategory"

type CategoryFormValues = z.infer<typeof categorySchema>

type CategoryFormProps = {
  initialData: any | null
}

export const CategoryForm: FC<CategoryFormProps> = ({ initialData }) => {
  const params = useParams()
  const router = useRouter()
  const { toast } = useToast()
  const [open, setOpen] = useState(false)
  const [loading, setLoading] = useState(false)
  const title = initialData ? "Edit category" : "Create category"
  const description = initialData ? "Edit a category." : "Add a new category"
  const toastMessage = initialData ? "Category updated." : "Category created."
  const action = initialData ? "Save changes" : "Create"

  const defaultValues = initialData
    ? initialData
    : {
        name: "",
        description: "",
      }

  const form = useForm<CategoryFormValues>({
    resolver: zodResolver(categorySchema),
    defaultValues,
  })

  const onSubmit = async (data: CategoryFormValues) => {
    try {
      setLoading(true)
      if (initialData) {
        useCreateCategory()
      } else {
        useUpdateCategory()
      }

      console.log("Category data: ", data)

      router.refresh()
      router.push(`/dashboard/category`)
      toast({
        variant: "destructive",
        title: "Success!",
        description: toastMessage,
      })
    } catch (error: any) {
      toast({
        variant: "destructive",
        title: "Uh oh! Something went wrong.",
        description: "There was a problem with your request.",
      })
    } finally {
      setLoading(false)
    }
  }

  return (
    <>
      <div className="flex items-center justify-between">
        <Heading title={title} description={description} />
        {initialData && (
          <Button
            disabled={loading}
            variant="destructive"
            size="sm"
            onClick={() => setOpen(true)}
          >
            <Trash className="h-4 w-4" />
          </Button>
        )}
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
              name="name"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Name</FormLabel>
                  <FormControl>
                    <Input
                      disabled={loading}
                      placeholder="Category name"
                      {...field}
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name="description"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Description</FormLabel>
                  <FormControl>
                    <Input
                      disabled={loading}
                      placeholder="Category description"
                      {...field}
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
          </div>
          <Button disabled={loading} className="ml-auto" type="submit">
            {action}
          </Button>
        </form>
      </Form>
    </>
  )
}
