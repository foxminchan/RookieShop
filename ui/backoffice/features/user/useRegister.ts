import { useMutation } from "@tanstack/react-query";
import userApi from "./user.service";
import { AuthUserResponse, RegisterRequest } from "./user.types";

function useRegister() {
  return useMutation<AuthUserResponse, AppAxiosError, RegisterRequest>({
    mutationFn: (data: RegisterRequest) => userApi.register(data),
  });
}

export default useRegister;
