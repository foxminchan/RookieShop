export default {
  default: {
    require: ["e2e/steps/*.ts"],
    format: ["pretty"],
    paths: ["e2e/features/*.feature"],
    parallel: 1,
    requireModule: ["ts-node/register"],
    publishQuiet: true,
  },
};
