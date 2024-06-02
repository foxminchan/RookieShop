import { sidebar } from "vuepress-theme-hope";

export default sidebar({
  "/": [
    "",
    {
      text: "Business Analysis",
      icon: "chart-simple",
      prefix: "model/",
      children: "structure",
    },
    {
      text: "System Design",
      icon: "sitemap",
      prefix: "design/",
      children: "structure",
    },
  ],
});
