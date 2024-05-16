type AxiosRequestConfig = import("axios").AxiosRequestConfig;

interface IAuthToken {
  access_token?: string;
  refresh_token?: string;
  access_token_expires_in?: number;
  access_token_expires_at?: number;
}

type ApiDataError = {
  type?: string;
  title: string;
  status?: number;
  errors?: {
    [key: string]: any;
  };
  detail?: string;
  instance?: string;
};

type AppAxiosError = import("axios").AxiosError<ApiDataError, any>;
