import { container } from "./configs/inversify.config";
import { TYPES } from "./constants/types";
import { IHttpService } from "./interfaces/iHttpService";
import { ILocalStorageService } from "./interfaces/iLocalStorageService";

const axiosService = container.get<IHttpService>(TYPES.IHttpService);
const localStorageService = container.get<ILocalStorageService>(
  TYPES.ILocalStorageService,
);

export { axiosService, localStorageService };
