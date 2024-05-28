import { FilterParams, PagingFilter } from "@/types/api"

/**
 * Generates a query string from an object's key-value pairs.
 * @param options - The object containing parameters for the query string.
 * @returns The query string (e.g., "key1=value1&key2=value2").
 */
export function buildQueryString(options: Record<string, any>): string {
  return Object.entries(options)
    .filter(([, value]) => value !== undefined)
    .map(
      ([key, value]) =>
        `${encodeURIComponent(key)}=${encodeURIComponent(value)}`
    )
    .join("&")
}
