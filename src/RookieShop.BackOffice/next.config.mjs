/** @type {import('next').NextConfig} */

import "./env.mjs"

const nextConfig = {
  reactStrictMode: false,
  images: {
    remotePatterns: [
      {
        protocol: "http",
        hostname: "**",
      },
    ],
  },
  async rewrites() {
    return [
      {
        source: "/api/:path*",
        destination: `${process.env.REMOTE_BFF}/api/v1/:path*`,
      },
      {
        source: "/bff/:path*",
        destination: `${process.env.REMOTE_BFF}/bff/:path*`,
      },
      {
        source: "/signin-oidc",
        destination: `${process.env.REMOTE_BFF}/signin-oidc`,
      },
      {
        source: "/signout-callback-oidc",
        destination: `${process.env.REMOTE_BFF}/signout-callback-oidc`,
      },
    ]
  },
  httpAgentOptions: {
    keepAlive: false,
  },
  logging: {
    fetches: {
      fullUrl: true,
    },
  },
  experimental: {
    instrumentationHook: true,
    turbo: {
      resolveExtensions: [
        ".mdx",
        ".tsx",
        ".ts",
        ".jsx",
        ".js",
        ".mjs",
        ".json",
      ],
    },
  },
}

export default nextConfig
