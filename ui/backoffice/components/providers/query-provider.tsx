"use client"

import { PropsWithChildren, useState } from "react"
import {
  MutationCache,
  QueryClient,
  QueryClientProvider,
} from "@tanstack/react-query"

import { toast } from "@/components/ui/use-toast"

export default function QueryProvider({
  children,
}: Readonly<PropsWithChildren>) {
  const [client] = useState(
    new QueryClient({
      mutationCache: new MutationCache({
        onError(error, _variables, _context, mutation) {
          if (mutation.options.onError) return

          toast({
            variant: "destructive",
            title: "Theres an error occurred",
            description: `${error.message}`,
          })
        },
      }),
    })
  )

  return <QueryClientProvider client={client}>{children}</QueryClientProvider>
}
