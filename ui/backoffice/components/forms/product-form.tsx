"use client"

import { FC, useEffect } from "react"
import Image from "next/image"
import { useParams, useRouter } from "next/navigation"
import useListCategories from "@/features/category/useListCategories"
import {
  ProductStatus,
  UpdateProductRequest,
} from "@/features/product/product.type"
import useCreateProduct from "@/features/product/useCreateProduct"
import useUpdateProduct from "@/features/product/useUpdateProduct"
import { zodResolver } from "@hookform/resolvers/zod"
import { useForm } from "react-hook-form"
import { z } from "zod"

import { productSchema } from "@/lib/validations/product"

import FileUpload from "../custom/file-upload"
import { Button } from "../ui/button"
import { Checkbox } from "../ui/checkbox"
import {
  Form,
  FormControl,
  FormDescription,
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
  SelectLabel,
  SelectTrigger,
  SelectValue,
} from "../ui/select"
import { Separator } from "../ui/separator"
import { useToast } from "../ui/use-toast"

type ProductFormValues = z.infer<typeof productSchema>

type ProductFormProps = {
  initialData: UpdateProductRequest | null
  currentProductImages?: string | null
}

export const ProductForm: FC<ProductFormProps> = ({
  initialData,
  currentProductImages,
}) => {
  const params = useParams()
  const router = useRouter()
  const { toast } = useToast()
  const {
    mutate: createProduct,
    isSuccess: createProductSuccess,
    isPending: createProductPending,
  } = useCreateProduct()
  const {
    mutate: updateProduct,
    isSuccess: updateProductSuccess,
    isPending: updateProductPending,
  } = useUpdateProduct()

  const { data } = useListCategories()

  const isDisabled =
    createProductPending ||
    updateProductPending ||
    createProductSuccess ||
    updateProductSuccess
  const title = initialData ? "Edit product" : "Create product"
  const description = initialData ? "Edit a product." : "Add a new product"
  const toastMessage = initialData ? "Product updated." : "Product created."
  const action = initialData ? "Save changes" : "Create"

  const defaultValues = initialData ?? {
    name: "",
    description: "",
    quantity: 0,
    price: 0,
    priceSale: 0,
    isDeletedOldImage: null,
    status: ProductStatus.OutOfStock,
    productImages: null,
    categoryId: null,
  }

  const form = useForm<ProductFormValues>({
    resolver: zodResolver(productSchema),
    // defaultValues,
  })

  const onSubmit = async (data: ProductFormValues) => {
    try {
      if (!initialData) {
        createProduct(data)
      } else {
        updateProduct({
          id: params.id as string,
          ...data,
        })
      }

      console.log("Product data: ", data)
    } catch (error: any) {
      toast({
        variant: "destructive",
        title: "Uh oh! Something went wrong.",
        description: "There was a problem with your request.",
      })
    }
  }

  useEffect(() => {
    if (createProductSuccess || updateProductSuccess) {
      toast({
        title: "Success!",
        description: toastMessage,
      })

      setTimeout(() => {
        router.replace(`/dashboard/product`)
      }, 2000)
    }
  }, [createProductSuccess, updateProductSuccess])

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
          encType="multipart/form-data"
        >
          <FormField
            control={form.control}
            name="productImages"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Images</FormLabel>
                <FormControl>
                  <FileUpload onChange={field.onChange} value={field.value} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          {initialData && currentProductImages && (
            <div className="gap-3 md:grid md:grid-cols-2 rounded-md border p-5">
              <Image
                src={currentProductImages}
                alt="Product image"
                width={50}
                height={50}
              />
              <FormField
                control={form.control}
                name="isDeletedOldImage"
                render={({ field }) => (
                  <FormItem className="flex flex-row items-start space-x-3 space-y-0 rounded-md border p-4">
                    <FormLabel></FormLabel>
                    <FormControl>
                      <Checkbox
                        checked={field.value}
                        onCheckedChange={field.onChange}
                      />
                    </FormControl>
                    <div className="space-y-1 leading-none">
                      <FormLabel>Remove old images</FormLabel>
                      <FormDescription>
                        Your old images will be removed.
                      </FormDescription>
                    </div>
                  </FormItem>
                )}
              />
            </div>
          )}
          <div className="gap-8 md:grid md:grid-cols-2">
            <FormField
              control={form.control}
              name="name"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Name</FormLabel>
                  <FormControl>
                    <Input
                      disabled={isDisabled}
                      placeholder="Product name"
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
                      disabled={isDisabled}
                      placeholder="Product description"
                      {...field}
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name="price"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Price</FormLabel>
                  <FormControl>
                    <Input
                      type="number"
                      min={0}
                      disabled={isDisabled}
                      placeholder="Product price"
                      {...field}
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name="priceSale"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Sale Price</FormLabel>
                  <FormControl>
                    <Input
                      type="number"
                      min={0}
                      disabled={isDisabled}
                      placeholder="Product sale price"
                      {...field}
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name="quantity"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Quantity</FormLabel>
                  <FormControl>
                    <Input
                      type="number"
                      min={0}
                      max={1000}
                      disabled={isDisabled}
                      placeholder="Product quantity"
                      {...field}
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            {initialData && (
              <FormField
                control={form.control}
                name="status"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Status</FormLabel>
                    <Select
                      onValueChange={field.onChange}
                      defaultValue={`${field.value}`}
                    >
                      <FormControl>
                        <SelectTrigger className="w-[180px]">
                          <SelectValue placeholder="Select status" />
                        </SelectTrigger>
                      </FormControl>
                      <SelectContent>
                        <SelectGroup>
                          <SelectLabel>Status</SelectLabel>
                          <SelectItem value={`${ProductStatus.InStock}`}>
                            In stock
                          </SelectItem>
                          <SelectItem value={`${ProductStatus.OutOfStock}`}>
                            Out of stock
                          </SelectItem>
                          <SelectItem value={`${ProductStatus.InStock}`}>
                            Out of stock
                          </SelectItem>
                        </SelectGroup>
                      </SelectContent>
                    </Select>
                    <FormMessage />
                  </FormItem>
                )}
              />
            )}
            <FormField
              control={form.control}
              name="categoryId"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Category</FormLabel>
                  <Select
                    onValueChange={field.onChange}
                    defaultValue={`${field.value}`}
                  >
                    <FormControl>
                      <SelectTrigger className="w-[180px]">
                        <SelectValue placeholder="Select category" />
                      </SelectTrigger>
                    </FormControl>
                    <SelectContent>
                      <SelectGroup>
                        <SelectLabel>Category</SelectLabel>
                        {data?.categories?.map((category) => (
                          <SelectItem key={category.id} value={category.id}>
                            {category.name}
                          </SelectItem>
                        ))}
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
