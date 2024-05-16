import "reflect-metadata";
import { Container } from "inversify";
import { IHttpService } from "../interfaces/iHttpService";
import HttpService from "../services/http.service";
import { TYPES } from "../constants/types";
import { ILocalStorageService } from "../interfaces/iLocalStorageService";
import LocalStorageService from "../services/localStorage.service";

const container = new Container();

container.bind<IHttpService>(TYPES.IHttpService).to(HttpService);
container
  .bind<ILocalStorageService>(TYPES.ILocalStorageService)
  .to(LocalStorageService);

export { container };
