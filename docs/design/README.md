# System Design

## High Level Design

The high level design of the system is based on the following components:

![Architecture Diagram](/RookieShop/system-design.png)

| No  | Name            | Usecase                                                                                              | Technology                |
| --- | --------------- | ---------------------------------------------------------------------------------------------------- | ------------------------- |
| 0   | ingress         | A reverse proxy that routes incoming requests to the appropriate service                             | Yarp                      |
| 1   | identity server | An authentication server that provides authentication and authorization services for the application | Duende IdentityServer 7.0 |
| 2   | store front     | A user-facing website that allows customers to view, rate, and purchase products                     | Razor, htmx, Alphine.js   |
| 3   | back office     | An admin-facing website that allows administrators to manage products, categories, and customers     | Next.js 14.0              |
| 4   | web api         | A REST API that provides data to the user-facing and admin-facing websites                           | ASP.NET Core 8.0          |
| 5   | redis           | A distributed lock manager, cache and cart storage                                                   | Redis                     |
| 6   | postgres        | A relational database that stores the application's data and email outbox                            | Postgres, Marten          |
| 7   | observability   | A telemetry data collector that collects and exports telemetry data to the Aspire Dashboard          | OpenTelemetry             |

## C4 Model

> TODO: Add C4 Model
