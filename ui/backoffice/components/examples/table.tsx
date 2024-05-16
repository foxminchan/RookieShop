"use client";

import React from "react";
import {
  createColumnHelper,
  getCoreRowModel,
  useReactTable,
  flexRender,
} from "@tanstack/react-table";
import { User } from "@/features/user/user.types";
import {
  Table,
  TableDataCell,
  TableHeaderCell,
  TableRow,
} from "../typos/table";

const exampleData: User[] = [
  {
    id: "b48fa5e2-bf95-4366-94a4-c9b0d76f9001",
    userName: "mcroyden0",
    email: "fwrigglesworth0@ehow.com",
  },
  {
    id: "5d2350d1-1b40-42a1-b386-3f2a4fa74fc2",
    userName: "kconnerry1",
    email: "alinscott1@hao123.com",
  },
  {
    id: "ac80328b-fcb1-4118-9588-c829b845417f",
    userName: "bgriffen2",
    email: "emeeland2@buzzfeed.com",
  },
  {
    id: "ec047397-38dc-469c-8bca-84e8b1cb23f0",
    userName: "kkildale3",
    email: "mpetersen3@meetup.com",
  },
  {
    id: "66cee794-bf46-41b7-8cf9-6905b753f97b",
    userName: "wduffin4",
    email: "lbanasik4@over-blog.com",
  },
  {
    id: "9959bdbd-37f1-47ff-9deb-c445faa6032b",
    userName: "hcrone5",
    email: "hcrone5@storify.com",
    fullName: "Hasheem Crone",
  },
  {
    id: "22463869-8f53-4e69-a43f-88100193db53",
    userName: "troubottom6",
    email: "troubottom6@gov.uk",
    fullName: "Timmy Roubottom",
  },
  {
    id: "e988794b-11c9-47ef-81d6-1e940362e1ec",
    userName: "pgiottoi7",
    email: "ctejero7@woothemes.com",
  },
  {
    id: "593ff079-d943-47a9-8c05-f31e0aabab4f",
    userName: "mcardenas8",
    email: "rmyrie8@guardian.co.uk",
  },
  {
    id: "16d6a2cd-e1a3-48ea-a042-89de9ad89177",
    userName: "fsyalvester9",
    email: "hdifrancesco9@timesonline.co.uk",
  },
];

const columnHelper = createColumnHelper<User>();

const columns = [
  columnHelper.accessor("id", {
    cell: (info) => info.getValue(),
  }),
  columnHelper.accessor("userName", {
    cell: (info) => info.getValue(),
  }),
  columnHelper.accessor("email", {
    cell: (info) => info.getValue(),
  }),
  columnHelper.accessor("fullName", {
    cell: (info) => <>{info.getValue() || "None"}</>,
  }),
];

function ExampleTable() {
  const table = useReactTable({
    columns: columns,
    data: exampleData,
    getCoreRowModel: getCoreRowModel(),
  });

  return (
    <Table>
      <thead>
        {table.getHeaderGroups().map((headerGroup) => (
          <TableRow key={headerGroup.id}>
            {headerGroup.headers.map((header) => (
              <TableHeaderCell key={header.id}>
                {header.isPlaceholder
                  ? null
                  : flexRender(
                      header.column.columnDef.header,
                      header.getContext(),
                    )}
              </TableHeaderCell>
            ))}
          </TableRow>
        ))}
      </thead>
      <tbody>
        {table.getRowModel().rows.map((row) => (
          <TableRow key={row.id}>
            {row.getVisibleCells().map((cell) => (
              <TableDataCell key={cell.id}>
                {flexRender(cell.column.columnDef.cell, cell.getContext())}
              </TableDataCell>
            ))}
          </TableRow>
        ))}
      </tbody>
    </Table>
  );
}

export default ExampleTable;
