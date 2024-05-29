/** @type {import('next').NextConfig} */

import "./env.mjs"

const nextConfig = {
  reactStrictMode: false,
  async rewrites() {
    return [
      {
        source: "/api/:path*",
        destination: `${process.env.NEXT_PUBLIC_BASE_API}/:path*`,
      },
    ]
  },
  httpAgentOptions: {
    keepAlive: false,
  },
}

export default nextConfig
