import {
  test,
  expect,
  chromium,
  Page,
  Browser,
  BrowserContext,
} from "@playwright/test";
import { LoginPage } from "../pages/login.page";

test.describe("Login Feature", () => {
  let page: Page;
  let browser: Browser | BrowserContext;
  let loginPage: LoginPage;

  test.beforeAll(async () => {
    browser = await chromium.launch();
    page = await browser.newPage();
    loginPage = new LoginPage(page, browser);
  });

  test("should log in with valid credentials", async () => {
    await loginPage.goto();
    await loginPage.setEmail("nguyenxuannhan@gmail.com");
    await loginPage.setPassword("P@ssw0rd");
    await loginPage.clickSubmit();

    const homeText = await loginPage.isHomePage();
    expect(homeText).toBe("Home");
  });

  test("should display error with invalid credentials", async () => {
    await loginPage.goto();
    await loginPage.setEmail("invalid@example.com");
    await loginPage.setPassword("wrongpassword");
    await loginPage.clickSubmit();

    const isErrorDisplayed = await loginPage.isErrorDisplayed();
    expect(isErrorDisplayed).toBeTruthy();
  });

  test.afterAll(async () => {
    await browser.close();
  });
});
