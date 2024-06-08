# System Design

## High Level Design

The high level design of the system is based on the following components:

![Architecture Diagram](/assets/image/architecture.png)

| No  | Name            | Usecase                                                                                              | Technology                                |
| --- | --------------- | ---------------------------------------------------------------------------------------------------- | ----------------------------------------- |
| 1   | back office     | An admin-facing website that allows administrators to manage products, categories, and customers     | Next.js 14.0                              |
| 2   | identity server | An authentication server that provides authentication and authorization services for the application | Duende IdentityServer 7.0                 |
| 3   | bff             | A backend for frontend that provides data to the admin-facing website                                | Yarp                                      |
| 4   | store front     | A user-facing website that allows customers to view, rate, and purchase products                     | Razor, htmx, Alphine.js, ///\_hyperscript |
| 5   | web api         | A REST API that provides data to the user-facing and admin-facing websites                           | ASP.NET Core 8.0                          |
| 6   | cache           | A distributed lock manager, cache and cart storage                                                   | Redis                                     |
| 7   | database        | A relational database that stores the application's data and email outbox                            | Postgres, Marten                          |
| 8   | observability   | A telemetry data collector that collects and exports telemetry data to the Aspire Dashboard          | OpenTelemetry                             |

## Why BFF Authentication?

<p align="justify">
The BFF (Backend for Frontend) pattern is a software design pattern that allows a backend service to be tailored to the needs of a specific frontend application. The BFF pattern is used to create a backend service that is optimized for a specific frontend application. This allows the backend service to provide the frontend application with the data and functionality it needs, without exposing the entire backend service to the frontend application. The BFF pattern is used to create a backend service that is optimized for a specific frontend application. This allows the backend service to provide the frontend application with the data and functionality it needs, without exposing the entire backend service to the frontend application.
</p>

## Patterns Used

1. Domain-Driven Design (DDD)
2. Domain Events
3. CQRS
4. Mediator
5. Chain of Responsibility
6. Repository
7. Specification
8. Options
9. Factory
10. Decorator
11. REPR
12. Builder

## C4 Model

### System Context Diagram

![System Context Diagram](/assets/image/context.png)

### Container Diagram

![Container Diagram](/assets/image/container.png)

### Component Diagram

> TODO: Add component diagram
