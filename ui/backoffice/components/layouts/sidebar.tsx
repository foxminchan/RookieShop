"use client";

import { cn } from "@/lib/utils";
import { useState } from "react";
import { navItems } from "@/lib/constants/data";
import { DashboardNav } from "./dashboard-nav";

type SidebarProps = {
  className?: string;
};

export default function Sidebar({ className }: Readonly<SidebarProps>) {
  const [status] = useState(false);

  return (
    <nav
      className={cn(
        `relative hidden h-screen border-r pt-20 md:block`,
        status && "duration-500",
        "w-72",
        className,
      )}
    >
      <div className="space-y-4 py-4">
        <div className="px-3 py-2">
          <div className="mt-3 space-y-1">
            <DashboardNav items={navItems} />
          </div>
        </div>
      </div>
    </nav>
  );
}
