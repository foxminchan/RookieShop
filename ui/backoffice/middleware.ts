import { auth } from "@/auth";
import { NextResponse } from "next/server";

export default auth(async (req) => {
  const { pathname } = req.nextUrl;
  if (!req.auth) {
    if (pathname === "/") {
      return NextResponse.next();
    } else {
      return NextResponse.redirect(new URL("/", req.url));
    }
  }
  if (req.auth && pathname === "/") {
    return NextResponse.redirect(new URL("/dashboard", req.url));
  }
  return NextResponse.next();
});

export const config = { matcher: ["/","/dashboard/:path*"] };
