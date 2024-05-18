FROM oven/bun:1.1.8-slim

ARG UID=1000
ARG GID=1000
RUN groupadd -g $GID nodejs && useradd -m -u $UID -g $GID nodejs

WORKDIR /app/next-app

COPY package.json ./
COPY bun.lockb ./

RUN bun install

USER nodejs

COPY --chown=nodejs:nodejs . .

ENV NEXT_TELEMETRY_DISABLED 1

CMD bun dev
