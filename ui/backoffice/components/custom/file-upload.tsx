"use client"

import Image from "next/image"
import { Trash } from "lucide-react"

import { IMG_MAX_SIZE } from "@/lib/constants/default"

import { Button } from "../ui/button"
import { Input } from "../ui/input"
import { Label } from "../ui/label"
import { useToast } from "../ui/use-toast"

type ImageUploadProps = {
  onChange?: any
  value?: File | null
}

export default function FileUpload({ onChange, value }: ImageUploadProps) {
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
                <Trash className="h-4 w-4" />
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
      <div className="flex items-center justify-center w-full">
        {!value && (
          <Label
            htmlFor="picture"
            className="flex flex-col items-center justify-center w-full h-54 border-2 border-gray-300 border-dashed rounded-lg cursor-pointer bg-gray-50 dark:hover:bg-bray-800 dark:bg-gray-700 hover:bg-gray-100 dark:border-gray-600 dark:hover:border-gray-500 dark:hover:bg-gray-600"
          >
            <div className="flex flex-col items-center justify-center pt-5 pb-6">
              <svg
                className="w-8 h-8 mb-4 text-gray-500 dark:text-gray-400"
                aria-hidden="true"
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 20 16"
              >
                <path
                  stroke="currentColor"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M13 13h3a3 3 0 0 0 0-6h-.025A5.56 5.56 0 0 0 16 6.5 5.5 5.5 0 0 0 5.207 5.021C5.137 5.017 5.071 5 5 5a4 4 0 0 0 0 8h2.167M10 15V6m0 0L8 8m2-2 2 2"
                />
              </svg>
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
