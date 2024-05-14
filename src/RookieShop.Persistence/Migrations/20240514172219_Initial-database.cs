using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Pgvector;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RookieShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initialdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .Annotation("Npgsql:PostgresExtension:vector", ",,");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 14, 17, 22, 17, 515, DateTimeKind.Utc).AddTicks(3626)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 14, 17, 22, 17, 515, DateTimeKind.Utc).AddTicks(3854)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("56707bd4-7d78-4579-bccc-09a2e6eed37e"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    gender = table.Column<byte>(type: "smallint", nullable: false),
                    account_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 14, 17, 22, 17, 515, DateTimeKind.Utc).AddTicks(9791)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 14, 17, 22, 17, 515, DateTimeKind.Utc).AddTicks(9999)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("272aa9a6-4f25-4aa0-9d25-6d1cd12696b6"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    embedding = table.Column<Vector>(type: "vector(384)", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    image_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 14, 17, 22, 17, 521, DateTimeKind.Utc).AddTicks(6367)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 14, 17, 22, 17, 521, DateTimeKind.Utc).AddTicks(6606)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("65d30891-237b-4ce4-8c0f-48c9709a9e59")),
                    price = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    card_brand_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    card_last4digits = table.Column<string>(type: "character(4)", fixedLength: true, maxLength: 4, nullable: true),
                    card_charge_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    shipping_address_street = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    shipping_address_city = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    shipping_address_province = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    payment_method = table.Column<byte>(type: "smallint", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 14, 17, 22, 17, 517, DateTimeKind.Utc).AddTicks(6496)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 14, 17, 22, 17, 517, DateTimeKind.Utc).AddTicks(6702)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("49cf61ae-ebdc-4687-8c62-b6ace80d1a8f"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    content = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 14, 17, 22, 17, 516, DateTimeKind.Utc).AddTicks(7286)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 14, 17, 22, 17, 516, DateTimeKind.Utc).AddTicks(7474)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("da261efa-b802-4575-b0a9-6a4c72023c41"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_feedbacks", x => x.id);
                    table.ForeignKey(
                        name: "fk_feedbacks_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_feedbacks_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_details",
                columns: table => new
                {
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 14, 17, 22, 17, 520, DateTimeKind.Utc).AddTicks(8045)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 14, 17, 22, 17, 520, DateTimeKind.Utc).AddTicks(8259)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("0d0c01e7-f257-483b-80fa-287710ab1069"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_details", x => new { x.order_id, x.product_id });
                    table.ForeignKey(
                        name: "fk_order_details_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_details_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "created_date", "description", "name", "version" },
                values: new object[,]
                {
                    { new Guid("07339a41-9592-4adf-a121-45ef2550b596"), new DateTime(2024, 5, 14, 17, 22, 17, 515, DateTimeKind.Utc).AddTicks(8643), "Electronics comprises the physics, engineering, technology and applications that deal with the emission, flow and control of electrons in vacuum and matter.", "Electronics", new Guid("04f67a60-e8d3-4dd2-8a3a-d9dead7e2374") },
                    { new Guid("09d65d8d-827a-43b1-a377-477c62cc9cf2"), new DateTime(2024, 5, 14, 17, 22, 17, 515, DateTimeKind.Utc).AddTicks(8630), "Clothes are items worn on the body. They are typically made of fabrics or textiles but over time have included garments made from animal skin or other thin sheets of materials put together.", "Clothes", new Guid("90f840f8-ca4a-458b-be58-d7be6dd65c0b") },
                    { new Guid("341f5112-ebc8-431e-91d3-ac35118e265a"), new DateTime(2024, 5, 14, 17, 22, 17, 515, DateTimeKind.Utc).AddTicks(8647), "Jewellery consists of small decorative items worn for personal adornment, such as brooches, rings, necklaces, earrings, pendants, bracelets, and cufflinks.", "Jewelry", new Guid("59632f81-53d6-4f05-8001-a3ba63005ded") },
                    { new Guid("56ac91ea-140b-4952-86ca-a26a991dcf22"), new DateTime(2024, 5, 14, 17, 22, 17, 515, DateTimeKind.Utc).AddTicks(8623), "A book is a medium for recording information in the form of writing or images, typically composed of many pages bound together and protected by a cover.", "Book", new Guid("1c8dcd2e-fa3c-4704-a05b-a12b18c49fb8") },
                    { new Guid("5cdd37b1-bb70-43bf-9453-537f8d50b8fd"), new DateTime(2024, 5, 14, 17, 22, 17, 515, DateTimeKind.Utc).AddTicks(8645), "Furniture refers to movable objects intended to support various human activities such as seating, eating, and sleeping.", "Furniture", new Guid("fd3d3204-9b4e-4ba7-b889-ad2cce3395ba") }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "account_id", "created_date", "email", "gender", "is_deleted", "name", "phone", "version" },
                values: new object[,]
                {
                    { new Guid("0dceb5c5-0528-407a-9555-2879159a5cc0"), null, new DateTime(2024, 5, 14, 17, 22, 17, 516, DateTimeKind.Utc).AddTicks(6202), "william.smith@gmail.com", (byte)1, false, "William Smith", "0123456789", new Guid("7b1030d3-e901-4702-b7c7-52d38d7c4102") },
                    { new Guid("1607e55d-4dc4-4fce-923f-5cc770c4a26c"), null, new DateTime(2024, 5, 14, 17, 22, 17, 516, DateTimeKind.Utc).AddTicks(6205), "maria.garcia@gmail.com", (byte)2, false, "Maria Garcia", "0123456789", new Guid("f44afe40-3d1c-4151-8602-204b7ad77f94") },
                    { new Guid("ad36836d-87d6-4801-a3af-a97c5a1c2fcb"), null, new DateTime(2024, 5, 14, 17, 22, 17, 516, DateTimeKind.Utc).AddTicks(6207), "anna.johnson@gmail.com", (byte)2, false, "Anna Johnson", "0123456789", new Guid("1aa1afd9-cc09-4e9e-9e1c-8ea25f604c1e") },
                    { new Guid("d3e82604-92a3-4b64-bbd5-d3051a78a439"), null, new DateTime(2024, 5, 14, 17, 22, 17, 516, DateTimeKind.Utc).AddTicks(6187), "john.doe@gmail.com", (byte)1, false, "John Doe", "0123456789", new Guid("3cbac8d8-5e08-43f9-9653-9e2c59eaf537") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_feedbacks_customer_id",
                table: "feedbacks",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_feedbacks_product_id",
                table: "feedbacks",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_details_product_id",
                table: "order_details",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_customer_id",
                table: "orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id",
                table: "products",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DropTable(
                name: "order_details");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
