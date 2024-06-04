"use client"

import { FC, useEffect } from "react"
import { useParams, useRouter } from "next/navigation"
import useListCategories from "@/features/category/useListCategories"
import {
  CreateProductRequest,
  ProductStatus,
  UpdateProductRequest,
} from "@/features/product/product.type"
import useCreateProduct from "@/features/product/useCreateProduct"
import useUpdateProduct from "@/features/product/useUpdateProduct"
import { zodResolver } from "@hookform/resolvers/zod"
import { useForm } from "react-hook-form"
import { z } from "zod"

import { cn } from "@/lib/utils"
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
  initialData: CreateProductRequest | UpdateProductRequest | null
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

  const defaultValues =
    initialData ??
    ({
      name: "",
      description: "",
      quantity: 0,
      price: 0,
      priceSale: 0,
      productImages: undefined,
      categoryId: undefined,
    } satisfies CreateProductRequest)

  const form = useForm<ProductFormValues>({
    resolver: zodResolver(productSchema),
    defaultValues,
  })

  const isDeleteImageSelected = form.watch("isDeletedOldImage")

  const onSubmit = async (data: ProductFormValues) => {
    debugger
    try {
      if (!initialData) {
        createProduct(data)
      } else {
        const { status, ...values } = data
        updateProduct({
          id: params.id as string,
          status: status ?? ProductStatus.InStock,
          ...values,
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
          <div
            className={cn("grid", initialData ? "grid-cols-4" : "grid-cols-3")}
          >
            <div className="col-span-3">
              <FormField
                control={form.control}
                name="productImages"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Images</FormLabel>
                    <FormControl>
                      <FileUpload
                        onChange={field.onChange}
                        value={field.value}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
            </div>
            {initialData && currentProductImages && (
              <div className="cols-span-1 space-y-4">
                <div className="w-full p-2">
                  <img
                    loading="lazy"
                    src={currentProductImages}
                    alt="Product image"
                    className={cn(
                      "w-full",
                      isDeleteImageSelected && "opacity-50"
                    )}
                  />
                </div>
                <FormField
                  control={form.control}
                  name="isDeletedOldImage"
                  render={({ field }) => (
                    <FormItem className="flex flex-row items-start space-x-3 space-y-0 rounded-md border p-4">
                      <FormLabel></FormLabel>
                      <FormControl>
                        <Checkbox
                          checked={field.value || undefined}
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
          </div>
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
                      defaultValue={
                        ProductStatus[field.value as keyof typeof ProductStatus]
                      }
                    >
                      <FormControl>
                        <SelectTrigger>
                          <SelectValue placeholder="Select status" />
                        </SelectTrigger>
                      </FormControl>
                      <SelectContent>
                        <SelectGroup>
                          <SelectLabel>Status</SelectLabel>
                          <SelectItem value={ProductStatus.InStock}>
                            In stock
                          </SelectItem>
                          <SelectItem value={ProductStatus.OutOfStock}>
                            Out of stock
                          </SelectItem>
                          <SelectItem value={ProductStatus.Discontinued}>
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
                    defaultValue={field.value}
                  >
                    <FormControl>
                      <SelectTrigger>
                        <SelectValue placeholder="Select a category" />
                      </SelectTrigger>
                    </FormControl>
                    <SelectContent>
                      <SelectGroup>
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
