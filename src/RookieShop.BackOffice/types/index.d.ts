export type NavItem = {
  id: number
  title: string
  href?: string
  disabled?: boolean
  external?: boolean
  label?: string
  description?: string
}

export type SiteConfig = {
  name: string
  description: string
  ogImage: string
  keywords?: string[]
  links: {
    github: string
  }
  authors?: {
    name: string
    url: string
  }
}

export type DataTableProps<TData, TValue> = {
  columns: ColumnDef<TData, TValue>[]
  data: TData[]
  searchKey: string
  pageNo: number
  totalRecords: number
  pageSizeOptions?: number[]
  pageCount: number
  searchParams?: {
    [key: string]: string | string[] | undefined | boolean
  }
}

export type AgentState = {
  topic: string
  searchResults?: string
  description?: string
  critique?: string
}
