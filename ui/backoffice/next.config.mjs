/** @type {import('next').NextConfig} */
const nextConfig = {
  reactStrictMode: false,
  httpAgentOptions: {
    keepAlive: false,
  },
};

export default nextConfig;
