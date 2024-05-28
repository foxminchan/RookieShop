import { AxiosRequestConfig, AxiosResponse } from "axios"

export default interface IHttpService {
  get<T>(
    url: string,
    config?: AxiosRequestConfig | undefined
  ): Promise<AxiosResponse<T>>

  post<T, R>(
    url: string,
    data: unknown,
    config: AxiosRequestConfig | undefined
  ): Promise<AxiosResponse<R>>

  put<T>(
    url: string,
    data: unknown,
    config: AxiosRequestConfig | undefined
  ): Promise<AxiosResponse<unknown, unknown>>

  patch<T>(
    url: string,
    data: unknown,
    config: AxiosRequestConfig | undefined
  ): Promise<AxiosResponse<T>>

  delete(
    url: string,
    config: AxiosRequestConfig | undefined
  ): Promise<AxiosResponse>

  setHttpConfigs(config?: Partial<AxiosRequestConfig>): void
}
