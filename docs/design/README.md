# System Design

## High Level Design

The high level design of the system is based on the following components:

![Architecture Diagram](/assets/image/architecture.png)

| No  | Name            | Usecase                                                                                              | Technology                                |
| --- | --------------- | ---------------------------------------------------------------------------------------------------- | ----------------------------------------- |
| 0   | ingress         | A reverse proxy that routes incoming requests to the appropriate service                             | Yarp                                      |
| 1   | identity server | An authentication server that provides authentication and authorization services for the application | Duende IdentityServer 7.0                 |
| 2   | store front     | A user-facing website that allows customers to view, rate, and purchase products                     | Razor, htmx, Alphine.js, ///\_hyperscript |
| 3   | back office     | An admin-facing website that allows administrators to manage products, categories, and customers     | Next.js 14.0                              |
| 4   | web api         | A REST API that provides data to the user-facing and admin-facing websites                           | ASP.NET Core 8.0                          |
| 5   | cache           | A distributed lock manager, cache and cart storage                                                   | Redis                                     |
| 6   | sql database    | A relational database that stores the application's data and email outbox                            | Postgres, Marten                          |
| 7   | observability   | A telemetry data collector that collects and exports telemetry data to the Aspire Dashboard          | OpenTelemetry                             |

## Patterns Used

<p align="justify">

1. **Domain-Driven Design (DDD)**: The system uses domain-driven design to model the domain of the application. Domain-driven design allows the system to model the domain of the application in a way that is aligned with the business requirements.
2. **Domain Events**: The system uses domain events to model the side effects of the domain. Domain events allow the system to model the side effects of the domain in a way that is decoupled from the domain logic.
3. **CQRS**: The system uses the CQRS pattern to separate the read and write concerns of the application. The write side of the application is implemented using commands and events, while the read side of the application is implemented using queries.
4. **Mediator**: The system uses the mediator pattern to decouple the components of the application. The mediator pattern allows the components of the application to communicate with each other without knowing the details of how they are implemented.
5. **Chain of Responsibility**: The system uses the chain of responsibility pattern to handle requests in a chain of handlers. The chain of responsibility pattern allows the system to process requests in a flexible and extensible way.
6. **Repository**: The system uses the repository pattern to abstract the data access layer of the application. The repository pattern allows the application to access data from different data sources without knowing the details of how they are implemented.
7. **Specification**: The system uses the specification pattern to define queries in a composable way. The specification pattern allows the system to define queries in a way that is easy to understand and maintain.
8. **Options**: The system uses the options pattern to configure the components of the application. The options pattern allows the application to be configured using configuration files or environment variables.
9. **Factory**: The system uses the factory pattern to create instances of objects. The factory pattern allows the system to create objects without knowing the details of how they are implemented.
10. **Decorator**: The system uses the decorator pattern to add behavior to objects dynamically. The decorator pattern allows the system to add behavior to objects without changing their interface.
11. **REPR**: Defines web API endpoints as having three components: a Request, an Endpoint, and a Response. It simplifies the frequently-used MVC pattern and is more focused on API development
12. **Builder**: The system uses the builder pattern to create complex objects. The builder pattern allows the system to create complex objects in a way that is easy to understand and maintain.

</p>

## C4 Model

> TODO: Add C4 Model
