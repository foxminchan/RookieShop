import { PagedInfo, PagingFilter } from "@/types/api"

// --- Types ---

export type Customer = {
  id: string
  name: string
  email: string
  phone: string
  gender: Gender
  accountId: string
}

export type ListCustomers = {
  pagedInfo: PagedInfo
  customers: Customer[]
}

export enum Gender {
  Male = 1,
  Female = 2,
  Other = 3,
}

export type CustomerFilterParams = PagingFilter & {
  search?: string | null
}
