"use client"

import useGetDiffRevenueByMonth from "@/features/report/useGetDiffRevenueByMonth"

import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card"
import { ScrollArea } from "@/components/ui/scroll-area"
import { Tabs, TabsContent } from "@/components/ui/tabs"
import { BestSeller } from "@/components/custom/best-seller"
import { Icons } from "@/components/custom/icons"
import { Overview } from "@/components/custom/overview"

export default function Dashboard() {
  const { data: DiffRevenueByMonth } = useGetDiffRevenueByMonth({
    sourceMonth: new Date().getMonth().toString(),
    sourceYear: new Date().getFullYear().toString(),
    targetMonth: (new Date().getMonth() + 1).toString(),
    targetYear: new Date().getFullYear().toString(),
  })

  return (
    <ScrollArea className="h-full">
      <div className="flex-1 space-y-4 p-4 pt-6 md:p-8">
        <div className="flex items-center justify-between space-y-2">
          <h2 className="text-3xl font-bold tracking-tight">
            Hi, Welcome back 👋
          </h2>
        </div>
        <Tabs defaultValue="overview" className="space-y-4">
          <TabsContent value="overview" className="space-y-4">
            <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
              <Card>
                <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                  <CardTitle className="text-sm font-medium">
                    Today Revenue
                  </CardTitle>
                  <Icons.dollar className="h-4 w-4 text-muted-foreground" />
                </CardHeader>
                <CardContent>
                  <div className="text-2xl font-bold">$45,231.89</div>
                </CardContent>
              </Card>
              <Card>
                <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                  <CardTitle className="text-sm font-medium">
                    Difference
                  </CardTitle>
                  <Icons.diff className="h-4 w-4 text-muted-foreground" />
                </CardHeader>
                <CardContent>
                  <div className="text-2xl font-bold">
                    {DiffRevenueByMonth?.diff ?? 0 >= 0 ? (
                      <span className="text-green-700">
                        +${DiffRevenueByMonth?.diff}
                      </span>
                    ) : (
                      <span className="text-red-700">
                        -${DiffRevenueByMonth?.diff}
                      </span>
                    )}
                  </div>
                </CardContent>
              </Card>
              <Card>
                <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                  <CardTitle className="text-sm font-medium">
                    Customers
                  </CardTitle>
                  <Icons.userPlus className="h-4 w-4 text-muted-foreground" />
                </CardHeader>
                <CardContent>
                  <div className="text-2xl font-bold">+12,234</div>
                </CardContent>
              </Card>
              <Card>
                <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                  <CardTitle className="text-sm font-medium">Orders</CardTitle>
                  <Icons.order className="h-4 w-4 text-muted-foreground" />
                </CardHeader>
                <CardContent>
                  <div className="text-2xl font-bold">+573</div>
                </CardContent>
              </Card>
            </div>
          </TabsContent>
        </Tabs>
      </div>
      <div className="grid grid-cols-1 gap-4 p-4 md:grid-cols-2 lg:grid-cols-7 md:p-8">
        <Card className="col-span-4">
          <CardHeader>
            <CardTitle>Overview</CardTitle>
          </CardHeader>
          <CardContent className="pl-2">
            <Overview />
          </CardContent>
        </Card>
        <Card className="col-span-4 md:col-span-3">
          <CardHeader>
            <CardTitle>Best Seller</CardTitle>
            <CardDescription>Top of best selling products</CardDescription>
          </CardHeader>
          <CardContent>
            <BestSeller />
          </CardContent>
        </Card>
      </div>
    </ScrollArea>
  )
}
