import { LoadingButton } from "@/components/custom/loading-button";
import { ModeToggle } from "@/components/custom/mode-toggle";
import SimpleTooltip from "@/components/custom/simple-tooltip";
import ExampleTable from "@/components/examples/table";
import { TypographyH1 } from "@/components/typos/h1";
import { TypographyH2 } from "@/components/typos/h2";
import { TypographyInlineCode } from "@/components/typos/inline-code";
import { TypographyLarge } from "@/components/typos/large";
import { TypographyLead } from "@/components/typos/lead";
import { Card } from "@/components/ui/card";
import Image from "next/image";

export default function Home() {
  return (
    <main className="flex min-h-dvh flex-col items-center justify-between container pb-24">
      <div className="min-h-dvh flex flex-col items-center justify-between p-24">
        <div className="z-10 w-full max-w-5xl items-center justify-between font-mono text-sm lg:flex">
          <Card>
            <div className="py-2 px-4">
              Styled with{" "}
              <a href="https://ui.shadcn.com/">
                <TypographyInlineCode>shadcn-ui</TypographyInlineCode>
              </a>
            </div>
          </Card>
          <div className="">
            <ModeToggle />
          </div>
        </div>
        <div className="flex flex-col space-y-8 justify-center items-center min-h-96">
          <div className="drop-shadow-xl">
            <TypographyH1 className="relative">
              <span>Next.js + shadcn/ui</span>{" "}
              <span className="bg-gradient-to-r from-pink-500 to-blue-500 bg-clip-text inline-block text-transparent">
                Extended
              </span>
            </TypographyH1>
          </div>
          <div className="grid grid-cols-3 items-center gap-4">
            <SimpleTooltip tooltipContent={"next.js"}>
              <Image
                className="w-24 h-24 dark:invert"
                alt="Next.js Logo"
                src={"/next.svg"}
                width={128}
                height={128}
              />
            </SimpleTooltip>
            <SimpleTooltip tooltipContent={"shadcn/ui"}>
              <Image
                className="w-fit h-24"
                alt="shadcn/ui logo"
                src={"/shadcnui-512x512.png"}
                width={512}
                height={512}
              />
            </SimpleTooltip>
            <SimpleTooltip tooltipContent={"react-query"}>
              <Image
                className="w-fit h-24"
                alt="React Query Logo"
                src={"/react-query-logo.png"}
                width={300}
                height={268}
              />
            </SimpleTooltip>
          </div>
        </div>
        <div className="mb-32 grid gap-4 text-center lg:mb-0 lg:w-full lg:max-w-5xl lg:grid-cols-4 lg:text-left">
          <Card>
            <div className="h-full p-2 flex justify-between items-center">
              <LoadingButton>Submit</LoadingButton>
              <LoadingButton isLoading>Click</LoadingButton>
            </div>
          </Card>
          <Card>
            <div className="h-full p-2 flex justify-center items-center">
              <SimpleTooltip tooltipContent="Simple Tooltip">
                <TypographyLarge>Simple Tooltip</TypographyLarge>
              </SimpleTooltip>
            </div>
          </Card>
          <Card>
            <div className="h-full p-2 flex justify-center items-center">
              <TypographyInlineCode>@tanstack/react-query</TypographyInlineCode>
            </div>
          </Card>
          <Card>
            <div className="h-full p-2 flex justify-center items-center">
              <TypographyLead>Typographies</TypographyLead>
            </div>
          </Card>
        </div>
      </div>
      <div>
        <TypographyH2>shadcnui Table + react-table</TypographyH2>
        <ExampleTable />
      </div>
    </main>
  );
}
