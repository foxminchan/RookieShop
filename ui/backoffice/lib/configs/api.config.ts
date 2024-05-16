const axiosConfigs: { [key: string]: AxiosRequestConfig } = {
  development: {
    baseURL: "/api/",
    withCredentials: true,
    timeout: 10000,
  },
  production: {
    baseURL: "/api/",
    withCredentials: true,
    timeout: 10000,
  },
  test: {
    baseURL: "/api/",
    withCredentials: true,
    timeout: 10000,
  },
};
const getAxiosConfig = (): AxiosRequestConfig => {
  const nodeEnv: string | undefined = process.env.NODE_ENV;
  return axiosConfigs[nodeEnv as keyof typeof axiosConfigs];
};

const axiosConfig = getAxiosConfig();

export default axiosConfig;
