"use client"

import { useEffect } from "react"
import { Button } from "@/components/ui/button"

export default function Error({
  error,
  reset,
}: Readonly<{
  error: Error & { digest?: string }
  reset: () => void
}>) {
  useEffect(() => {
    console.error(error)
  }, [error])

  return (
    <div className="p-24 flex items-center justify-center container mx-auto min-h-dvh">
      <div className="flex flex-col space-y-4">
        <h2 className="text-4xl font-bold">Something went wrong!</h2>
        <Button onClick={() => reset()}>Try again</Button>
      </div>
    </div>
  )
}
