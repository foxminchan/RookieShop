FROM oven/bun:1.1.8-slim

WORKDIR /ui/backoffice

COPY package.json ./

RUN bun install

COPY . .

ENV NEXT_TELEMETRY_DISABLED 1

USER bun

CMD bun dev
