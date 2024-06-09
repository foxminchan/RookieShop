"use client"

import Image from "next/image"

import { IMG_MAX_SIZE } from "@/lib/constants/default"

import { Button } from "../ui/button"
import { Input } from "../ui/input"
import { Label } from "../ui/label"
import { useToast } from "../ui/use-toast"
import { Icons } from "./icons"

type ImageUploadProps = {
  onChange?: any
  value?: File | null
}

export default function FileUpload({
  onChange,
  value,
}: Readonly<ImageUploadProps>) {
  const { toast } = useToast()

  const onDeleteFile = () => {
    onChange(null)
  }

  return (
    <>
      <div className="mb-4 flex items-center gap-4">
        {value && (
          <div className="relative h-[200px] w-[200px] overflow-hidden rounded-md">
            <div className="absolute right-2 top-2 z-10">
              <Button
                type="button"
                onClick={() => onDeleteFile()}
                variant="destructive"
                size="sm"
              >
                <Icons.trash className="h-4 w-4" />
              </Button>
            </div>
            <div>
              <Image
                src={URL.createObjectURL(value)}
                alt="Product image"
                layout="fill"
                objectFit="cover"
              />
            </div>
          </div>
        )}
      </div>
      <div className="flex w-full items-center justify-center">
        {!value && (
          <Label
            htmlFor="picture"
            className="dark:hover:bg-bray-800 flex h-80 w-full cursor-pointer flex-col items-center justify-center rounded-lg border-2 border-dashed border-gray-300 bg-gray-50 hover:bg-gray-100 dark:border-gray-600 dark:bg-gray-700 dark:hover:border-gray-500 dark:hover:bg-gray-600"
          >
            <div className="flex flex-col items-center justify-center pb-6 pt-5">
              <Icons.upload className="mb-4 h-8 w-8 text-gray-500 dark:text-gray-400" />
              <p className="mb-2 text-sm text-gray-500 dark:text-gray-400">
                <span className="font-semibold">Click to upload</span> or drag
                and drop
              </p>
              <p className="text-xs text-gray-500 dark:text-gray-400">
                PNG, JPG or JPEG (MAX: 1MB)
              </p>
            </div>
            <Input
              type="file"
              id="picture"
              accept="image/*"
              className="hidden"
              onChange={(e) => {
                const file = e.target.files?.[0]
                if (file) {
                  if (file.size > IMG_MAX_SIZE) {
                    toast({
                      variant: "destructive",
                      title: "Uh oh! Something went wrong.",
                      description: "Image size must be less than 1MB",
                    })
                  } else if (
                    !["image/jpeg", "image/png", "image/jpg"].includes(
                      file.type
                    )
                  ) {
                    toast({
                      variant: "destructive",
                      title: "Uh oh! Something went wrong.",
                      description: "Image must be in jpeg, jpg, or png format",
                    })
                  } else {
                    onChange(file)
                  }
                }
              }}
            />
          </Label>
        )}
      </div>
    </>
  )
}
