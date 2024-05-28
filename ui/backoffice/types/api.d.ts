type BasePaging = {
  pageNumber: number
  pageSize: number
}

export type PagedInfo = BasePaging & {
  totalPages: number
  totalRecords: number
}

export type PagingFilter = BasePaging

export type FilterParams = BasePaging & {
  isDescending: boolean
  orderBy: string
}
