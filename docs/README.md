# Introduction

## Description

<p align="justify">
Rookie Shop is a .NET Core web application training project demonstrating Clean Architecture, DDD, and modern web development using Aspire and Next.js. It is part of the Rookie Phase-1 Assignment at NashTech.
</p>

<p align="justify">
Rookie Shop uses Clean Architecture and DDD to ensure maintainability, scalability, and effective communication between developers and domain experts. It also integrates Aspire, a mature framework, to streamline development and provide a robust foundation for building modern web applications.
</p>

<p align="justify">
Rookie Shop uses Next.js to enhance performance, provide an intuitive development experience, and create dynamic, responsive web interfaces.
</p>

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

::: tip

<p align="justify">
The project should apply as many techniques of ASP.NET MVC Core as possible. For example: TagHelpers, Razor Pages, ViewComponents and have Unit Test. The Unit Test do not need to have a high coverage number but should demonstrate the ability to write unit test for common components: Controllers, ViewComponents, Services …
</p>

:::

## Technical Stack

- [ASP.NET Core 8.0](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0): A cross-platform, high-performance, open-source framework for building modern, cloud-based, Internet-connected applications.
- [htmx](https://htmx.org/): A JavaScript library that allows you to access AJAX, WebSockets, and Server-Sent Events directly in HTML, using attributes.
- [Alphine.js](https://alpinejs.dev/): A rugged, minimal framework for composing JavaScript behavior in your markup.
- [Next.js 14.0](https://nextjs.org/): A React framework that enables functionality such as server-side rendering and generating static websites for React-based web applications.
- [Duende IdentityServer 7.0](https://duendesoftware.com/products/identityserver): An authentication server that provides authentication and authorization services for the application.
- [Redis](https://redis.io/): An open-source, in-memory data structure store used as a database, cache, and message broker.
- [Postgres](https://www.postgresql.org/): A powerful, open-source object-relational database system.
- [Aspire](https://learn.microsoft.com/dotnet/aspire): An opinionated, cloud ready stack for building observable, production ready, distributed applications.
- [Yarp](https://microsoft.github.io/reverse-proxy/): A reverse proxy that routes incoming requests to the appropriate service.
- [OpenTelemetry](https://opentelemetry.io/): An observability framework for cloud-native software.
- [NUKE](https://nuke.build/): A cross-platform build automation system with C# DSL.
