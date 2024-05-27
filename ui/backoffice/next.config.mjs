/** @type {import('next').NextConfig} */

import "./env.mjs";

const nextConfig = {
  reactStrictMode: false,
  httpAgentOptions: {
    keepAlive: false,
  },
};

export default nextConfig;
