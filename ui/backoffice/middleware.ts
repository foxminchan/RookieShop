import { NextRequest, NextResponse } from "next/server"
import { RateLimiterMemory } from "rate-limiter-flexible"

const rateLimiter = new RateLimiterMemory({
  points: 20,
  duration: 1,
})

export function middleware(request: NextRequest) {
  try {
    rateLimiter.consume(request.ip || "")
    return NextResponse.next()
  } catch (rateLimiterRes) {
    return new NextResponse("Too many requests", { status: 429 })
  }
}

export const config = { matcher: ["/", "/dashboard/:path*"] }
