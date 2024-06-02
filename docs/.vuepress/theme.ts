import { hopeTheme } from "vuepress-theme-hope";
import navbar from "./navbar.js";
import sidebar from "./sidebar.js";

export default hopeTheme({
  hostname: "https://vuepress-theme-hope-docs-demo.netlify.app",

  author: {
    name: "Nhan Nguyen",
    url: "https://github.com/foxminchan",
  },

  iconAssets: "fontawesome-with-brands",

  logo: "/logo.png",

  repo: "foxminchan/RookieShop",

  docsDir: "src",

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
      mermaid: true,
    },
  },
});
