"use client";

import dataProviderSimpleRest from "@refinedev/simple-rest";

const API_URL = process.env.BASE_URL ?? "https://localhost:9000/api/v1";

export const dataProvider = dataProviderSimpleRest(API_URL);
