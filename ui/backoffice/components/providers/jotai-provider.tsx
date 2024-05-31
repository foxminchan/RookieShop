import React, { PropsWithChildren } from "react"
import { Provider } from "jotai"

export default function JotaiProvider({
  children,
}: Readonly<PropsWithChildren>) {
  return <Provider>{children}</Provider>
}
