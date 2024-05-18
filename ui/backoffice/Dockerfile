FROM oven/bun:1.1.8-slim

WORKDIR /app/next-app

COPY package.json ./
COPY bun.lockb ./
RUN bun install

COPY . .

ENV NEXT_TELEMETRY_DISABLED 1

USER bun

CMD bun dev
