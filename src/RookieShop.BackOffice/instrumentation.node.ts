import { Resource } from "@opentelemetry/resources"
import { NodeSDK } from "@opentelemetry/sdk-node"
import { SEMRESATTRS_SERVICE_NAME } from "@opentelemetry/semantic-conventions"

const sdk = new NodeSDK({
  resource: new Resource({
    [SEMRESATTRS_SERVICE_NAME]: "backoffice",
  }),
  spanProcessors: [],
})

sdk.start()
