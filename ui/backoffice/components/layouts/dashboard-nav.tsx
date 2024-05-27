"use client";

import Link from "next/link";
import { cn } from "@/lib/utils";
import { usePathname } from "next/navigation";
import { NavItem } from "@/lib/@types/global";
import { Dispatch, SetStateAction } from "react";

type DashboardNavProps = {
  items: NavItem[];
  setOpen?: Dispatch<SetStateAction<boolean>>;
};

export function DashboardNav({ items, setOpen }: Readonly<DashboardNavProps>) {
  const path = usePathname();

  if (!items?.length) {
    return null;
  }

  return (
    <nav className="grid items-start gap-2">
      {items.map((item) => {
        return (
          item.href && (
            <Link
              href={item.disabled ? "/" : item.href}
              className={cn(
                "flex items-center gap-2 overflow-hidden rounded-md py-2 text-sm font-medium hover:bg-accent hover:text-accent-foreground",
                path === item.href ? "bg-accent" : "transparent",
                item.disabled && "cursor-not-allowed opacity-80",
              )}
              onClick={() => {
                if (setOpen) setOpen(false);
              }}
            >
              <span className="ml-2 truncate ml-3">{item.title}</span>
            </Link>
          )
        );
      })}
    </nav>
  );
}
