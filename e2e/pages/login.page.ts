import { Page, Browser, BrowserContext } from "@playwright/test";

export class LoginPage {
  private page: Page;
  private browser: Browser | BrowserContext;
  private baseUrl = "https://localhost:4000/User/Account/Login";

  constructor(page: Page, browser: Browser | BrowserContext) {
    this.page = page;
    this.browser = browser;
  }

  async setEmail(email: string) {
    await this.page.locator('[placeholder="Username"]').fill(email);
  }

  async setPassword(password: string) {
    await this.page.locator('[placeholder="Password"]').fill(password);
  }

  async clickSubmit() {
    await this.page.getByRole("button", { name: "Login" }).click();
  }

  async isErrorDisplayed(): Promise<boolean> {
    return await this.page.locator(".alert-danger").isVisible();
  }

  async isHomePage(): Promise<string | null> {
    const headingLocator = this.page.getByRole("heading", {
      name: "Welcome to Rookie Shop",
    });
    return await headingLocator.textContent();
  }

  async goto() {
    await this.page.goto(this.baseUrl);
  }
}
