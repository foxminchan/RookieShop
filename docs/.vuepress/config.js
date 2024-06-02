import { defaultTheme } from "@vuepress/theme-default";
import { defineUserConfig } from "vuepress/cli";
import { viteBundler } from "@vuepress/bundler-vite";

export default defineUserConfig({
  lang: "en-US",

  base: "/RookieShop/",
  title: "RookieShop",
  description:
    "A project developed by a rookie transitioning to an engineer at NashTech",

  theme: defaultTheme({
    displayAllHeaders: true,
    logo: "/logo.png",
    docsDir: "docs",
    repo: "foxminchan/RookieShop",
    editLinks: false,
    editLinkText: "Help us improve this page!",
    nav: [{ text: "Home", link: "/" }],
    sidebar: ["/", "/model/", "/design/"],
  }),
  head: [["link", { rel: "icon", href: "favicon.ico" }]],
  bundler: viteBundler(),
});
