import { oidcConfig } from "@/auth"
import { User, UserManager } from "oidc-client-ts"

class AuthService {
  public userManager: UserManager

  constructor() {
    this.userManager = new UserManager(oidcConfig)
  }

  public getUserAsync(): Promise<User | null> {
    return this.userManager.getUser()
  }

  public loginAsync(): Promise<void> {
    return this.userManager.signinRedirect()
  }

  public completeLoginAsync(url: string): Promise<void | User> {
    return this.userManager.signinCallback(url)
  }

  public renewTokenAsync(): Promise<User | null> {
    return this.userManager.signinSilent()
  }

  public logoutAsync(): Promise<void> {
    return this.userManager.signoutRedirect()
  }

  public async completeLogoutAsync(url: string): Promise<void> {
    await this.userManager.signoutCallback(url)
  }
}

export default new AuthService()
