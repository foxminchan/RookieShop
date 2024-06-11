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
| 9   | ai platform     | An AI platform that provides AI services for the application                                         | OpenAI, Tavily                            |

## Why BFF Authentication?

<p align="justify">
Backend for Frontend (BFF) Authentication is a security approach designed to optimize both user experience and security in web applications. Utilizing standard OAuth flows, BFF Authentication enables backend clients to authenticate users seamlessly, setting up session cookies to maintain secure and smooth interactions.
</p>

@startuml
participant BackOffice as spa
participant BFF as bff
participant IdentityServer as identityserver
participant API as api

spa -> bff: Open login page
bff -> identityserver: Redirect to IdentityServer login page
spa <- bff: Redirect response (IdentityServer login page URL)

spa -> identityserver: Access IdentityServer login page
identityserver -> spa: Display login form

spa -> identityserver: Submit credentials
identityserver -> identityserver: Validate credentials
identityserver -> spa: Redirect with authorization code

spa -> bff: Send authorization code
bff -> identityserver: Exchange authorization code for tokens
identityserver -> bff: Access token and ID token

bff -> spa: Set cookies (access token)

spa -> bff: Request data from API
bff -> api: Forward request with access token
api -> bff: Return data
bff -> spa: Return data

@enduml

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
