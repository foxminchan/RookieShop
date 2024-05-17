import { useMutation } from "@tanstack/react-query";
import userApi from "./user.service";
import { AuthUserResponse, RegisterRequest } from "./user.types";
import { AxiosResponse } from "axios";

function useRegister() {
  return useMutation<
    AxiosResponse<AuthUserResponse>,
    AppAxiosError,
    RegisterRequest
  >({
    mutationFn: (data: RegisterRequest) => userApi.register(data),
  });
}

export default useRegister;
