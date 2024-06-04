/// <reference lib="dom" />

import "@testing-library/jest-dom"

import { render, screen } from "@testing-library/react"
import { describe, expect, test } from "bun:test"

import ProductPage from "@/app/(dashboard)/dashboard/product/page"

describe("Page", () => {
  test("renders a heading", () => {
    render(<ProductPage searchParams={{}} />)

    const heading = screen.getByRole("heading", { name: "Product" })

    expect(heading.innerText).toBe("Product")
  })
})
