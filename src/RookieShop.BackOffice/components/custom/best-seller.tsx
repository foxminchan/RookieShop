"use client"

import Link from "next/link"
import useGetBestSellerProducts from "@/features/report/useGetBestSellerProducts"

import { Avatar, AvatarFallback } from "@/components/ui/avatar"

export default function BestSeller() {
  const { data } = useGetBestSellerProducts({ top: 5 })
  return (
    <div className="space-y-8">
      {data?.map((bestSeller, key) => (
        <div key={bestSeller.productId} className="flex items-center">
          <Avatar className="h-9 w-9">
            <AvatarFallback>{key + 1}</AvatarFallback>
          </Avatar>
          <div className="ml-4 space-y-1">
            <Link
              href={`/dashboard/product/${bestSeller.productId}`}
              className="text-sm font-medium leading-none"
            >
              {bestSeller.productName}
            </Link>
            <p className="text-sm text-muted-foreground">
              ${bestSeller.price.priceSale.toFixed(2)}{" "}
            </p>
          </div>
          <div className="ml-auto font-medium">
            {bestSeller.totalSoldQuantity}
          </div>
        </div>
      ))}
    </div>
  )
}
