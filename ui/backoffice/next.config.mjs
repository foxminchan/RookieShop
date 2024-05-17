/** @type {import('next').NextConfig} */
const nextConfig = {
  reactStrictMode: false,
  async rewrites() {
    return [
      {
        source: "/api/:path*",
        destination: `${process.env.API_BASEURL}/:path*`,
      },
    ];
  },
  httpAgentOptions: {
    keepAlive: false,
  },
};

export default nextConfig;
