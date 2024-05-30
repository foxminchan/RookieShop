import { Toaster } from "@/components/ui/toaster"
import { TooltipProvider } from "@/components/ui/tooltip"
import OidcProvider from "@/components/providers/oidc-provider"
import JotaiProvider from "@/components/providers/jotai-provider"
import QueryProvider from "@/components/providers/query-provider"
import { ThemeProvider } from "@/components/providers/theme-provider"

export default function Providers({
  children,
}: Readonly<{
  children: React.ReactNode
}>) {
  return (
    <JotaiProvider>
      <ThemeProvider
        attribute="class"
        defaultTheme="system"
        enableSystem
        disableTransitionOnChange
      >
        <QueryProvider>
          <TooltipProvider>
            <OidcProvider>{children}</OidcProvider>
          </TooltipProvider>
        </QueryProvider>
        <Toaster />
      </ThemeProvider>
    </JotaiProvider>
  )
}
