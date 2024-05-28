import { auth } from "@/auth"
import { NextResponse } from "next/server"
import { RateLimiterMemory } from "rate-limiter-flexible"

const rateLimiter = new RateLimiterMemory({
  points: 20,
  duration: 1,
})

export default auth(async (req) => {
  try {
    await rateLimiter.consume(req.ip as string)
    const { pathname } = req.nextUrl
    if (!req.auth) {
      if (pathname === "/") {
        return NextResponse.next()
      } else {
        return NextResponse.redirect(new URL("/", req.url))
      }
    }
    if (req.auth && pathname === "/") {
      return NextResponse.redirect(new URL("/dashboard", req.url))
    }
    return NextResponse.next()
  } catch (rateLimiterRes) {
    return new NextResponse("Too many requests", { status: 429 })
  }
})

export const config = { matcher: ["/", "/dashboard/:path*"] }
