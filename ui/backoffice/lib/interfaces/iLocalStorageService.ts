export interface ILocalStorageService {
  set<T>(key: string, value: T): void;
  get<T, D>(key: string, defaultValue: D): T;
  remove(key: string): void;
  clear(): void;
}
