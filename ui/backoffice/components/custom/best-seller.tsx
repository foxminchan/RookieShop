"use client"

import useGetBestSellerProducts from "@/features/report/useGetBestSellerProducts"

import { Avatar, AvatarFallback } from "@/components/ui/avatar"

export function BestSeller() {
  const { data } = useGetBestSellerProducts({ top: 5 })
  return (
    <div className="space-y-8">
      {data?.map((bestSeller, key) => (
        <div key={bestSeller.productId} className="flex items-center">
          <Avatar className="h-9 w-9">
            <AvatarFallback>{key + 1}</AvatarFallback>
          </Avatar>
          <div className="ml-4 space-y-1">
            <p className="text-sm font-medium leading-none">
              {bestSeller.productName}
            </p>
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
