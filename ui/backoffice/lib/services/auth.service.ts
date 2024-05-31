import { User, UserManager, UserManagerSettings } from "oidc-client-ts"

import { oidcConfig, oidcStorageName } from "../configs/oicd.config"

export class AuthService {
  oidcConfig: UserManagerSettings = oidcConfig
  userManager: UserManager = new UserManager(oidcConfig)
  getUser() {
    const oidcStorage = window.localStorage.getItem(oidcStorageName)
    return oidcStorage ? User.fromStorageString(oidcStorage) : null
  }
}

export const authService = new AuthService()
