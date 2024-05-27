import axios, {
  AxiosError,
  AxiosInstance,
  AxiosResponse,
  AxiosRequestConfig,
} from "axios";
import _omitBy from "lodash/omitBy";
import axiosConfig from "@/lib/configs/api.config";

export default class HttpService {
  private instance: AxiosInstance;

  constructor(config = axiosConfig) {
    const axiosConfigs = config;

    const instance = axios.create({ ...axiosConfigs });
    Object.assign(instance, this.setupInterceptorsTo(instance));
    this.instance = instance;
  }

  private onResponse = (response: AxiosResponse) => {
    return response.data;
  };

  private onResponseError = (error: AxiosError): Promise<AxiosError> => {
    return Promise.reject(error);
  };

  private setupInterceptorsTo(axiosInstance: AxiosInstance): AxiosInstance {
    axiosInstance.interceptors.request.use(
      async (config) => {
        return config;
      },
      (error) => {
        console.error(`[request error] [${JSON.stringify(error)}]`);
        return Promise.reject(new Error(error));
      },
    );
    axiosInstance.interceptors.response.use(
      async (response) => {
        return this.onResponse(response);
      },
      (error) => {
        return this.onResponseError(error);
      },
    );
    return axiosInstance;
  }

  public async get<T>(
    url: string,
    config: AxiosRequestConfig | undefined = undefined,
  ): Promise<AxiosResponse<T>> {
    return await this.instance.get<T, AxiosResponse<T>>(`${url}`, config);
  }

  public async post<T>(
    url: string,
    data: unknown = undefined,
    config: AxiosRequestConfig | undefined = undefined,
  ): Promise<AxiosResponse<T>> {
    return await this.instance.post<T, AxiosResponse<T>>(url, data, config);
  }

  public async put<T>(
    url: string,
    data: unknown = undefined,
    config: AxiosRequestConfig | undefined = undefined,
  ): Promise<AxiosResponse<unknown, unknown>> {
    return await this.instance.put<T, AxiosResponse<T>>(url, data, config);
  }

  public async patch<T>(
    url: string,
    data: unknown = undefined,
    config: AxiosRequestConfig | undefined = undefined,
  ): Promise<AxiosResponse<T>> {
    return await this.instance.patch<T, AxiosResponse<T>>(url, data, config);
  }

  public async delete<T>(
    url: string,
    config: AxiosRequestConfig | undefined = undefined,
  ): Promise<AxiosResponse<T>> {
    return await this.instance.delete<T, AxiosResponse<T>>(url, config);
  }

  public setHttpConfigs(config?: Partial<AxiosRequestConfig>) {
    if (config?.baseURL) {
      this.instance.defaults.baseURL = config.baseURL;
    }

    this.instance.defaults = {
      ...this.instance.defaults,
      ..._omitBy(config, "BaseURL"),
    };
  }
}
