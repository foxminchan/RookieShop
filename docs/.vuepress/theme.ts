import { hopeTheme } from "vuepress-theme-hope";
import navbar from "./navbar.js";
import sidebar from "./sidebar.js";

export default hopeTheme({
  hostname: "https://foxminchan.github.io/RookieShop/",

  author: {
    name: "Nhan Nguyen",
    url: "https://github.com/foxminchan",
  },

  iconAssets: "fontawesome-with-brands",

  logo: "/logo.png",

  repo: "foxminchan/RookieShop",

  docsDir: "docs",

  // navbar
  navbar,

  // sidebar
  sidebar,

  footer: "RookieShop © Nhan Nguyen",

  displayFooter: true,

  metaLocales: {
    editLink: "Edit this page on GitHub",
  },

  plugins: {
    components: {
      components: ["Badge", "VPCard"],
    },

    searchPro: true,

    mdEnhance: {
      align: true,
      attrs: true,
      codetabs: true,
      component: true,
      demo: true,
      figure: true,
      imgLazyload: true,
      imgSize: true,
      include: true,
      mark: true,
      plantuml: true,
      spoiler: true,
      stylize: [
        {
          matcher: "Recommended",
          replacer: ({ tag }) => {
            if (tag === "em")
              return {
                tag: "Badge",
                attrs: { type: "tip" },
                content: "Recommended",
              };
          },
        },
      ],
      sub: true,
      sup: true,
      tabs: true,
      tasklist: true,
      vPre: true,
    },
  },
});
