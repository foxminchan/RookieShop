import { useMutation } from "@tanstack/react-query";
import userApi from "./user.service";
import { AuthUserResponse, LoginRequest } from "./user.types";

function useLogin() {
  return useMutation<AuthUserResponse, AppAxiosError, LoginRequest>({
    mutationFn: (data: LoginRequest) => userApi.login(data),
  });
}

export default useLogin;
