"use client"

import { FC, useEffect } from "react"
import { useParams, useRouter } from "next/navigation"
import { UpdateCategoryRequest } from "@/features/category/category.type"
import useCreateCategory from "@/features/category/useCreateCategory"
import useUpdateCategory from "@/features/category/useUpdateCategory"
import { zodResolver } from "@hookform/resolvers/zod"
import { useForm } from "react-hook-form"
import * as z from "zod"

import { categorySchema } from "@/lib/validations/category"

import CustomEditor from "../custom/custom-editor"
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
import { Separator } from "../ui/separator"
import { useToast } from "../ui/use-toast"

type CategoryFormValues = z.infer<typeof categorySchema>

type CategoryFormProps = {
  initialData: UpdateCategoryRequest | null
}

export const CategoryForm: FC<CategoryFormProps> = ({ initialData }) => {
  const params = useParams()
  const router = useRouter()
  const { toast } = useToast()
  const {
    mutate: createCategory,
    isSuccess: createCategorySuccess,
    isPending: createCategoryPending,
  } = useCreateCategory()
  const {
    mutate: updateCategory,
    isSuccess: updateCategorySuccess,
    isPending: updateCategoryPending,
  } = useUpdateCategory()
  const isDisabled =
    createCategoryPending ||
    updateCategoryPending ||
    createCategorySuccess ||
    updateCategorySuccess
  const title = initialData ? "Edit category" : "Create category"
  const description = initialData ? "Edit a category." : "Add a new category"
  const toastMessage = initialData ? "Category updated." : "Category created."
  const action = initialData ? "Save changes" : "Create"

  const defaultValues = initialData ?? {
    name: "",
    description: "",
  }

  console.log("defaultValues", defaultValues)

  const form = useForm<CategoryFormValues>({
    resolver: zodResolver(categorySchema),
    defaultValues,
  })

  const onSubmit = async (data: CategoryFormValues) => {
    try {
      if (!initialData) {
        createCategory(data)
      } else {
        updateCategory({
          id: params.id as string,
          ...data,
        })
      }

      console.log("Category data: ", data)
    } catch (error: any) {
      toast({
        variant: "destructive",
        title: "Uh oh! Something went wrong.",
        description: "There was a problem with your request.",
      })
    }
  }

  useEffect(() => {
    if (createCategorySuccess || updateCategorySuccess) {
      toast({
        title: "Success!",
        description: toastMessage,
      })

      setTimeout(() => {
        router.replace(`/dashboard/category`)
      }, 2000)
    }
  }, [createCategorySuccess, updateCategorySuccess])

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
          <FormField
            control={form.control}
            name="name"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Name</FormLabel>
                <FormControl>
                  <Input
                    disabled={isDisabled}
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
                  <CustomEditor
                    content={initialData?.description ?? ""}
                    handleContent={(content: string) => {
                      form.setValue("description", content)
                    }}
                    disabled={isDisabled}
                    {...field}
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <Button disabled={isDisabled} className="ml-auto" type="submit">
            {action}
          </Button>
        </form>
      </Form>
    </>
  )
}
