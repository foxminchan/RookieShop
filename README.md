<h1>RookieShop: Rookie Phase-1 Assignment Project</h1>

[![Build](https://github.com/foxminchan/RookieShop/actions/workflows/build.yml/badge.svg?branch=main)](https://github.com/foxminchan/RookieShop/actions/workflows/build.yml)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=foxminchan_RookieShop&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=foxminchan_RookieShop)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)

<p align="justify">
RookieShop Web Application is a assignment project for training purpose. The project is a web application make the best practices of .NET Core in Clean Architecture and Domain-Driven Design and contain multiple design-patterns and principles. It demonstrates how to build a modern web application using .NET Core with Aspire Dashboard and Next.js with Bun.
</p>

<hr/>

<h2>Table of Contents</h2>

- [Requirements](#requirements)
- [Technical Stack](#technical-stack)
- [Software Architecture](#software-architecture)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
    - [Windows with Visual Studio](#windows-with-visual-studio)
    - [Mac, Linux, \& Windows without Visual Studio](#mac-linux--windows-without-visual-studio)
  - [Setup tools and dependencies](#setup-tools-and-dependencies)
  - [Start the infrastructure](#start-the-infrastructure)
  - [Running the application](#running-the-application)
- [Testing](#testing)
- [Observability](#observability)
- [Project References](#project-references)
- [License](#license)
- [Organization](#organization)

## Requirements

Build an e-commerce web site with minimum functionality below:

**For customers:**

- `Home page: category menu, features products`
- `View products by category`
- `View product details`
- `Product rating`
- Register
- Login/Logout
- Optional (Shopping Cart, Ordering, IdentityServer4)

**For admin:**

- Login/logout
- `Manage product categories (Name, Description)`
- `Manage products (Name, Category, Description, Price, Images, CreatedDate, UpdatedDate)`
- `View customers`

> [!NOTE]
>
> <p align="justify">
> The project should apply as many techniques of ASP.NET MVC Core as possible. For example: TagHelpers, Razor Pages, ViewComponents and have Unit Test. The Unit Test do not need to have a high coverage number but should demonstrate the ability to write unit test for common components: Controllers, ViewComponents, Services …
> </p>

## Technical Stack

- [ASP.NET Core 8.0](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0)
- [Next.js 14.0](https://nextjs.org/)
- [Duende IdentityServer 7.0](https://duendesoftware.com/products/identityserver)
- [Redis](https://redis.io/)
- [Postgres](https://www.postgresql.org/)
- [Aspire](https://learn.microsoft.com/dotnet/aspire)
- [OpenTelemetry](https://opentelemetry.io/)

## Software Architecture

<img loading="lazy" src="./img/system-design.png" alt="System Design" width="100%" height="100%">

## Getting Started

### Prerequisites

- Get the latest source code: [https://github.com/foxminchan/RookieShop](https://github.com/foxminchan/RookieShop)
- Install & start Docker Desktop: [https://docs.docker.com/engine/install/](https://docs.docker.com/engine/install/)
- Install Node.js: [https://nodejs.org/en/download/](https://nodejs.org/en/download/)
- Install bun: [https://bun.sh/](https://bun.sh/)

#### Windows with Visual Studio

- Install [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)

#### Mac, Linux, & Windows without Visual Studio

- Install the latest [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download)
- Install [Visual Studio Code with C# Dev Kit](https://code.visualstudio.com/docs/csharp/get-started)

> Or use JetBrains Rider for the best experience

### Setup tools and dependencies

```bash
# Setup the tools

bun install
dotnet tool restore

# Install the dependencies for the backend

cd RookieShop
dotnet restore ./RookieShop.sln

# Install the admin-facing website dependencies

cd ../backoffice
bun install
```

### Start the infrastructure

```bash
docker-compose --env-file .env up -d
```

> [!IMPORTANT]
> Create a `.env` file in the root directory and set the environment variables.

**You can access the following services:**

1. `https://localhost:9000` for all the REST API document
2. `https://localhost:5001` for identity server
3. `https://localhost:4000` for user facing website
4. `https://localhost:3000` for admin facing website
5. `https://localhost:1888` for observability dashboard

### Running the application

> [!WARNING]
> Remember to ensure that Docker is started

1. Run the backend

- (Windows only) Run the application from Visual Studio:
- Open the `RookieShop.sln` solution file in Visual Studio
- Ensure `RookieShop.ApiService` and `RookieShop.IdentityService` are set as the startup projects
- Hit `F5` to run the application
- Or run the application from your terminal:

```bash
dotnet run --project src/RookieShop.ApiService/RookieShop.ApiService.csproj
dotnet run --project src/RookieShop.IdentityService/RookieShop.IdentityService.csproj
```

2. Run the frontend for the user-facing website

```bash
dotnet run --project ui/storefront/RookieShop.Storefront.csproj
```

3. Run the frontend for the admin-facing website

```bash
cd ui/backoffice && bun dev
```

## Testing

<p align="justify">
In the project, we use xUnit for unit testing and Moq for mocking. For integration testing, we use the <code>TestContainers</code> for running the test in the Docker container. I also use the <code>NetArchTest</code> library to enforce the architecture rules in the project. The test project is located in the <code>test</code> folder. I follow the <b>Test Pyramid</b> strategy to write the test. To run the test, you can use the following command:
</p>

```bash
dotnet test RookieShop.sln
```

> [!NOTE]
> For performance testing, we use the <code>K6</code> tool to simulate the load on the application. To run the performance test, you can use the following:
>
> ```bash
> k6 run ./k6/performance-test.js
> ```

## Observability

<p align="justify">
The project uses OpenTelemetry to collect the telemetry data from the application. The data is sent to the OpenTelemetry Collector and exported to the Aspire Dashboard. The Aspire Dashboard is a monitoring and observability tool that provides insights into the application's performance and behavior. It helps developers to identify and troubleshoot issues in the application.
</p>

<img loading="lazy" src="./img/aspire-dashboard.png" alt="Aspire Dashboard" width="100%" height="100%">

## Project References

- https://github.com/dotnet/eShop
- https://github.com/ardalis/CleanArchitecture
- https://github.com/thangchung/clean-architecture-dotnet
- https://github.com/phongnguyend/Practical.CleanArchitecture

## License

This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details.

## Organization

<a href="https://www.nashtechglobal.com/" target="_blank">
	<img loading="lazy" src="./img/nash-tech.png" alt="NashTech" width="80" height="80">
</a>
