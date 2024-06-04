# Business Analysis

## Business Context

<p align="justify">
RookieShop, a promising new online store, is set to transform the way we shop for books, souvenirs, stationery, and art supplies. This platform will serve as a virtual showcase for unique, personalized products from local artists and creators, reaching a wide range of customers across the country. With its user-friendly interface, RookieShop allows sellers to easily manage their online stores, expand their customer base, and grow their businesses.
</p>

<p align="justify">
For customers, RookieShop is the ideal destination to discover unique and meaningful items. The website's homepage will highlight featured products and collections, accompanied by interesting stories about their origin, concept, and creative process. Customers can easily search for products by categories such as books, stationery, souvenirs, and art supplies. Detailed product information, high-quality images, and reviews from other customers will provide a comprehensive shopping experience, enabling customers to make informed purchasing decisions.
</p>

<p align="justify">
On the administrative side, RookieShop equips administrators with powerful tools to manage product categories, add or remove product listings, and collect customer data for personalized marketing campaigns. These tools will help manage the store efficiently, ensuring an engaging and enjoyable shopping experience for both sellers and buyers.
</p>

<p align="justify">
By combining a diverse product range, convenient shopping experience, and user-friendly interface, RookieShop promises to become a vibrant online shopping hub, promoting the growth of local artists and creators, while providing customers with unique, meaningful, and high-quality products.
</p>

## Conceptual Model

<div align="center">

@startuml
CUSTOMER ||--o{ ORDER : places
ORDER ||--|{ ORDER_ITEM : contains
PRODUCT ||--o{ ORDER_ITEM : belongs to
CATEGORY ||--o{ PRODUCT : within
CUSTOMER ||--o{ FEEDBACK : writes
PRODUCT ||--o{ FEEDBACK : has
@enduml

</div>

## Entity Relationship Diagram

![Entity Relationship Diagram](/assets/image/erd.png)

## Event Storming

### Step 1: Define Events

![Collect domain events](/assets/image/collect-event.jpg)

### Step 2: Refine Events

![Refine domain events](/assets/image/refine-event.jpg)

### Step 3: Track Cause and Effect

![Track cause and effect](/assets/image/track-cause.jpg)

### Step 4: Find Aggregates and Boundaries

![Find aggregates and boundaries](/assets/image/aggregates.jpg)

## User Stories

### Customer User Stories

- **As a customer**, I want to browse through different product categories (books, souvenirs, stationery, art supplies) so that I can easily find what I'm looking for.
- **As a customer**, I want to view detailed product information, including descriptions, images, and prices, so that I can make informed purchasing decisions.
- **As a customer**, I want to read reviews from other customers so that I can gauge the quality and popularity of a product.
- **As a customer**, I want to create an account and log in so that I can save my shipping information, track my orders, and receive personalized recommendations.
- **As a customer**, I want to add items to a shopping cart and proceed to checkout so that I can purchase the products I want.
- **As a customer**, I want to be able to search for specific products by keyword or title so that I can quickly find what I need.

### Seller User Stories

- **As a seller**, I want to create and manage my online store on RookieShop so that I can showcase my products to a wider audience.
- **As a seller**, I want to add, edit, and remove product listings, including descriptions, images, and prices, so that I can keep my store up-to-date.
- **As a seller**, I want to receive notifications for new orders and track the status of my shipments so that I can manage my inventory and fulfill orders promptly.
- **As a seller**, I want to communicate with customers to answer questions and address concerns so that I can provide excellent customer service.

### Administrator User Stories

- **As an administrator**, I want to review and approve new seller applications so that I can maintain the quality and integrity of the marketplace.
- **As an administrator**, I want to monitor and manage user accounts, including sellers and customers, so that I can ensure a safe and secure platform.
- **As an administrator**, I want to access sales data and analytics so that I can track the performance of the marketplace and make informed business decisions.
- **As an administrator**, I want to manage content on the website, such as featured products and promotions, so that I can attract and engage users.
