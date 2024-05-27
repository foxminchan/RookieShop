import JotaiProvider from "@/components/providers/jotai-provider";
import QueryProvider from "@/components/providers/query-provider";
import { ThemeProvider } from "@/components/providers/theme-provider";
import { Toaster } from "@/components/ui/toaster";
import { TooltipProvider } from "@/components/ui/tooltip";
import { SessionProvider, SessionProviderProps } from "next-auth/react";

function Providers({
  session,
  children,
}: Readonly<{
  session: SessionProviderProps["session"];
  children: React.ReactNode;
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
            <SessionProvider session={session}>{children}</SessionProvider>
          </TooltipProvider>
        </QueryProvider>
        <Toaster />
      </ThemeProvider>
    </JotaiProvider>
  );
}

export default Providers;
