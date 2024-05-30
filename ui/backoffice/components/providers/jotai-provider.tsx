import { Provider } from "jotai"
import React, { PropsWithChildren } from "react"

function JotaiProvider({ children }: Readonly<PropsWithChildren>) {
  return <Provider>{children}</Provider>
}

export default JotaiProvider
