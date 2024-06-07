import axios, { AxiosInstance, AxiosRequestConfig, AxiosResponse } from "axios"
import _omitBy from "lodash/omitBy"
import { v4 as uuidv4 } from "uuid"

import axiosConfig from "../configs/api.config"

export default class HttpService {
  private instance: AxiosInstance

  constructor(config = axiosConfig) {
    const axiosConfigs = config

    const instance = axios.create({ ...axiosConfigs })
    Object.assign(instance, this.setupInterceptorsTo(instance))
    this.instance = instance
  }

  private setupInterceptorsTo(axiosInstance: AxiosInstance): AxiosInstance {
    axiosInstance.interceptors.request.use(
      async (config) => {
        return config
      },
      (error) => {
        console.error(`[request error] [${JSON.stringify(error)}]`)
        return Promise.reject(new Error(error))
      }
    )
    axiosInstance.interceptors.response.use(
      async (response) => {
        return response.data
      },
      (error) => {
        return Promise.reject(new Error(error))
      }
    )
    return axiosInstance
  }

  public async get<T>(url: string, config?: AxiosRequestConfig): Promise<T> {
    return (await this.instance.get<T, AxiosResponse<T>>(url, config)) as T
  }

  public async post<T = unknown, R = null>(
    url: string,
    data?: T,
    config?: AxiosRequestConfig
  ): Promise<R> {
    config = {
      ...config,
      headers: {
        "X-Idempotency-Key": uuidv4(),
      },
    }
    return await this.instance.post<T, R>(url, data, config)
  }

  public async put<T = unknown, R = null>(
    url: string,
    data: T,
    config?: AxiosRequestConfig
  ): Promise<R> {
    return await this.instance.put<T, R>(url, data, config)
  }

  public async patch<T = unknown, R = null>(
    url: string,
    data: T,
    config?: AxiosRequestConfig
  ): Promise<R> {
    config = {
      ...config,
      headers: {
        "X-Idempotency-Key": uuidv4(),
      },
    }
    return await this.instance.patch<T, R>(url, data, config)
  }

  public async delete(url: string, config?: AxiosRequestConfig): Promise<void> {
    return await this.instance.delete(url, config)
  }

  public setHttpConfigs(config?: Partial<AxiosRequestConfig>): void {
    if (config?.baseURL) {
      this.instance.defaults.baseURL = config.baseURL
    }

    this.instance.defaults = {
      ...this.instance.defaults,
      ..._omitBy(config, "BaseURL"),
    }
  }
}
