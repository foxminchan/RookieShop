const config = {
  content: [
    "./Pages/**/*.cshtml",
    "./Views/**/*.cshtml",
    "./Areas/**/*.cshtml",
    "./Components/**/*.razor",
  ],
  theme: {
    extend: {},
  },
  plugins: [],
  variants: {
    extend: {
      display: ["group-hover"],
    },
  },
};

export default config;
