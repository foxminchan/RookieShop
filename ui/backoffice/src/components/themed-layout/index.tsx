"use client";

import { AppIcon } from "@components/app-icon";
import { Header } from "@components/header";
import { ThemedLayoutV2, ThemedTitleV2 } from "@refinedev/mui";
import React from "react";

export const ThemedLayout = ({ children }: React.PropsWithChildren) => {
  return (
    <ThemedLayoutV2
      Header={() => <Header sticky />}
      Title={({ collapsed }) => (
        <ThemedTitleV2
          collapsed={collapsed}
          text="Rookie Shop"
          icon={<AppIcon />}
        />
      )}
    >
      {children}
    </ThemedLayoutV2>
  );
};
