import { Provider } from "jotai"
import React, { PropsWithChildren } from "react"

export default function JotaiProvider({
  children,
}: Readonly<PropsWithChildren>) {
  return <Provider>{children}</Provider>
}
