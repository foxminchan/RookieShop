import { Given, When, Then } from "@cucumber/cucumber";
import { Browser, BrowserContext, Page, chromium, expect } from "@playwright/test";
import { LoginPage } from "../pages/login.page";

let page: Page;
let browser: Browser | BrowserContext;
let loginPage: LoginPage;

Given("a logged out user on the login page", async function () {
  browser = await chromium.launch({ headless: true });
  const context = await browser.newContext();
  page = await context.newPage();
  loginPage = new LoginPage(page, browser);
  await loginPage.goto();
});

When("the user logs in with valid credentials", async function () {
  await loginPage.setEmail("valid-email@example.com");
  await loginPage.setPassword("valid-password");
  await loginPage.clickSubmit();
});

When(
  "the user logs in with invalid credentials like email {string} and password {string}",
  async function (email: string, password: string) {
    await loginPage.setEmail(email);
    await loginPage.setPassword(password);
    await loginPage.clickSubmit();
  }
);

Then("they log in successfully", async function () {
  const headingText = await loginPage.isHomePage();
  expect(headingText).toBe("Welcome to Rookie Shop");
  await browser.close();
});

Then("login error message should be displayed", async function () {
  const isErrorVisible = await loginPage.isErrorDisplayed();
  expect(isErrorVisible).toBe(true);
  await browser.close();
});
