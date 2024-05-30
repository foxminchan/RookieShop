import { env } from "./env.mjs"
import { UserManagerSettings } from "oidc-client-ts"

export const oidcConfig: UserManagerSettings = {
  authority: env.NEXT_PUBLIC_DUENDE_AUTHORITY,
  client_id: env.NEXT_PUBLIC_DUENDE_CLIENT_ID,
  redirect_uri: env.NEXT_PUBLIC_REDIRECT_URI,
  post_logout_redirect_uri: env.NEXT_PUBLIC_POST_LOGOUT_REDIRECT_URI,
  response_type: env.NEXT_PUBLIC_RESPONSE_TYPE,
  scope: env.NEXT_PUBLIC_DUENDE_CLIENT_SCOPE,
  automaticSilentRenew: true,
  includeIdTokenInSilentRenew: true,
  monitorSession: true,
}
