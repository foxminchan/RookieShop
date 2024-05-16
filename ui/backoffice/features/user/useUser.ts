import { keepPreviousData, useQuery } from "@tanstack/react-query";
import userApi from "./user.service";

function useUser() {
  return useQuery({
    queryKey: [`@me`],
    queryFn: () => userApi.getUser(),
    placeholderData: keepPreviousData,
  });
}

export default useUser;
