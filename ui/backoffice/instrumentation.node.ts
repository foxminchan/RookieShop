import { OTLPTraceExporter } from "@opentelemetry/exporter-trace-otlp-http"
import { Resource } from "@opentelemetry/resources"
import { NodeSDK } from "@opentelemetry/sdk-node"
import { SimpleSpanProcessor } from "@opentelemetry/sdk-trace-node"
import { SEMRESATTRS_SERVICE_NAME } from "@opentelemetry/semantic-conventions"

const sdk = new NodeSDK({
  resource: new Resource({
    [SEMRESATTRS_SERVICE_NAME]: "backoffice",
  }),
  spanProcessor: new SimpleSpanProcessor(new OTLPTraceExporter()),
})

sdk.start()
