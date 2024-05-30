;("")

import { NextRequest, NextResponse } from "next/server"
import { RateLimiterMemory } from "rate-limiter-flexible"
import userManager from "./lib/configs/oicd.config"

const rateLimiter = new RateLimiterMemory({
  points: 50,
  duration: 1,
})

export async function middleware(request: NextRequest) {
  // // rateLimiter.consume(request.ip || "")
  // if (!(await userManager.getUser())) {
  //   return new NextResponse("", { status: 302, headers: { Location: "/" } })
  // } else {
  //   return new NextResponse("", {
  //     status: 302,
  //     headers: { Location: "/dashboard" },
  //   })
  // }
}

export const config = { matcher: ["/", "/dashboard/:path*"] }
