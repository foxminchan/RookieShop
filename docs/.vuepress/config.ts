import { defineUserConfig } from "vuepress";
import theme from "./theme.js";

export default defineUserConfig({
  base: "/RookieShop/",
  lang: "en-US",
  title: "RookieShop",
  description:
    "A project developed by a rookie transitioning to an engineer at NashTech",
  theme,
});
