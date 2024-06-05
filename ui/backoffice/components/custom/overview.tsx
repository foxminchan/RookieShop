"use client"

import useGetRevenueByYear from "@/features/report/useGetRevenueByYear"
import { Bar, BarChart, ResponsiveContainer, XAxis, YAxis } from "recharts"

export default function Overview() {
  const { data: RevenueByYear } = useGetRevenueByYear({
    year: new Date().getFullYear(),
  })
  return (
    <ResponsiveContainer width="100%" height={350}>
      <BarChart data={RevenueByYear}>
        <XAxis
          dataKey="month"
          stroke="#888888"
          fontSize={12}
          tickLine={false}
          axisLine={false}
        />
        <YAxis
          stroke="#888888"
          fontSize={12}
          tickLine={false}
          axisLine={false}
          tickFormatter={(value) => `$${value}`}
        />
        <Bar dataKey="revenue" fill="#adfa1d" radius={[4, 4, 0, 0]} />
      </BarChart>
    </ResponsiveContainer>
  )
}
