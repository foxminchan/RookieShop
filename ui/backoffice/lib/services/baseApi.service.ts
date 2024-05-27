import Http from "@/lib/services/http.service";

export default class BaseApiService {
  protected httpClient: Http;

  constructor() {
    this.httpClient = new Http();
  }
}
