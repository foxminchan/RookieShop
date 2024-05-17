"use client";

import HttpService from "@/lib/services/http.service";
import {
  AuthUserResponse,
  LoginRequest,
  RegisterRequest,
  User,
} from "./user.types";

class UserApiService extends HttpService {
  constructor() {
    super();
  }

  register(data: RegisterRequest) {
    return this.post<AuthUserResponse>("/users/register", data);
  }

  login(data: LoginRequest) {
    return this.post<AuthUserResponse>("/users/login", data);
  }

  getUserById(id: string) {
    return this.get<User>(`/users/${id}`);
  }

  getUsers() {
    return this.get<User[]>(`/users`);
  }

  getMe() {
    return this.get<User>(`/users/@me`);
  }

  getUser = this.getMe;
}

const userApi = new UserApiService();

export default userApi;
