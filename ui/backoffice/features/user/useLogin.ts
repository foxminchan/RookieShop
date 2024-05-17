import { useMutation } from "@tanstack/react-query";
import userApi from "./user.service";
import { AuthUserResponse, LoginRequest } from "./user.types";
import { AxiosResponse } from "axios";

function useLogin() {
  return useMutation<
    AxiosResponse<AuthUserResponse>,
    AppAxiosError,
    LoginRequest
  >({
    mutationFn: (data: LoginRequest) => userApi.login(data),
  });
}

export default useLogin;
