using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pgvector;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RookieShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initializedatabase : Migration
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 14, 7, 5, 37, 380, DateTimeKind.Utc).AddTicks(2209)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 14, 7, 5, 37, 380, DateTimeKind.Utc).AddTicks(2624)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("9c9c07e9-f6f5-40bc-8817-ff90ad8e82f3"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 14, 7, 5, 37, 381, DateTimeKind.Utc).AddTicks(1210)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 14, 7, 5, 37, 381, DateTimeKind.Utc).AddTicks(1472)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("cd4378c8-7e52-410c-889f-5e41bada21cf"))
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
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 14, 7, 5, 37, 387, DateTimeKind.Utc).AddTicks(3843)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 14, 7, 5, 37, 387, DateTimeKind.Utc).AddTicks(4178)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("25563ade-bca5-40a2-bd43-b5d6a4ad05c0")),
                    price = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id");
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
                    customer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 14, 7, 5, 37, 382, DateTimeKind.Utc).AddTicks(7382)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 14, 7, 5, 37, 382, DateTimeKind.Utc).AddTicks(7708)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("914ec23a-00f3-457c-87c8-3a17934dadf4"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id");
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 14, 7, 5, 37, 382, DateTimeKind.Utc).AddTicks(2055)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 14, 7, 5, 37, 382, DateTimeKind.Utc).AddTicks(2338)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("bcc02e42-15d2-426b-9fd1-3906a9e4020d"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_feedbacks", x => x.id);
                    table.ForeignKey(
                        name: "fk_feedbacks_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_feedbacks_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_image",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    alt = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_main = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_image", x => new { x.id, x.product_id });
                    table.ForeignKey(
                        name: "fk_product_image_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_details",
                columns: table => new
                {
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 14, 7, 5, 37, 386, DateTimeKind.Utc).AddTicks(5904)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 14, 7, 5, 37, 386, DateTimeKind.Utc).AddTicks(6226)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("455c60a8-1f8c-4cfd-b19c-a206f694d20e"))
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "created_date", "description", "name", "version" },
                values: new object[,]
                {
                    { new Guid("197bcf44-6ce6-40ba-a475-a86f1074fb60"), new DateTime(2024, 5, 14, 7, 5, 37, 380, DateTimeKind.Utc).AddTicks(9486), "Clothes are items worn on the body. They are typically made of fabrics or textiles but over time have included garments made from animal skin or other thin sheets of materials put together.", "Clothes", new Guid("f7562f6d-f28e-41e2-bf32-b795edb8b04e") },
                    { new Guid("5f40e579-3ff2-4beb-9b66-2bd8a59ae707"), new DateTime(2024, 5, 14, 7, 5, 37, 380, DateTimeKind.Utc).AddTicks(9501), "Electronics comprises the physics, engineering, technology and applications that deal with the emission, flow and control of electrons in vacuum and matter.", "Electronics", new Guid("e767aeb9-8d5d-4bc7-845a-da6f05496343") },
                    { new Guid("7684f67c-01b2-4327-9780-c2218aaaeda6"), new DateTime(2024, 5, 14, 7, 5, 37, 380, DateTimeKind.Utc).AddTicks(9474), "A book is a medium for recording information in the form of writing or images, typically composed of many pages bound together and protected by a cover.", "Book", new Guid("e93b6470-64d1-4272-a91a-67a11ec4fc67") },
                    { new Guid("785f3e7c-e341-4679-ac64-64c2a9f8b5a2"), new DateTime(2024, 5, 14, 7, 5, 37, 380, DateTimeKind.Utc).AddTicks(9506), "Jewellery consists of small decorative items worn for personal adornment, such as brooches, rings, necklaces, earrings, pendants, bracelets, and cufflinks.", "Jewelry", new Guid("c17a06eb-d730-488d-aee1-86bdd7903083") },
                    { new Guid("900bce1c-a11e-4ef9-bd1c-3cc9c7030664"), new DateTime(2024, 5, 14, 7, 5, 37, 380, DateTimeKind.Utc).AddTicks(9504), "Furniture refers to movable objects intended to support various human activities such as seating, eating, and sleeping.", "Furniture", new Guid("1bb7b516-82f3-414c-bc68-64bec31bd863") }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "account_id", "created_date", "email", "gender", "is_deleted", "name", "phone", "version" },
                values: new object[,]
                {
                    { new Guid("5e350e29-0d24-4517-8129-2b0b27665fa1"), null, new DateTime(2024, 5, 14, 7, 5, 37, 382, DateTimeKind.Utc).AddTicks(454), "anna.johnson@gmail.com", (byte)2, false, "Anna Johnson", "0123456789", new Guid("19334114-d6b4-4254-8d8e-67b6e0ff458d") },
                    { new Guid("7a0adf1a-0432-4a4f-b00c-bc578f76bd22"), null, new DateTime(2024, 5, 14, 7, 5, 37, 382, DateTimeKind.Utc).AddTicks(428), "john.doe@gmail.com", (byte)1, false, "John Doe", "0123456789", new Guid("b1bf594a-aabc-4433-a48e-8b2534516bec") },
                    { new Guid("81f737b3-faa0-473f-8aab-4a4534c1d3f5"), null, new DateTime(2024, 5, 14, 7, 5, 37, 382, DateTimeKind.Utc).AddTicks(451), "maria.garcia@gmail.com", (byte)2, false, "Maria Garcia", "0123456789", new Guid("f5b5c01d-ab0f-4f39-b860-28eb07ff5805") },
                    { new Guid("884dbba0-7472-4a36-bfd6-991f1b12a863"), null, new DateTime(2024, 5, 14, 7, 5, 37, 382, DateTimeKind.Utc).AddTicks(446), "william.smith@gmail.com", (byte)1, false, "William Smith", "0123456789", new Guid("e4461d51-ab65-425e-83be-22090554dc35") }
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
                name: "ix_product_image_product_id",
                table: "product_image",
                column: "product_id");

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
                name: "product_image");

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
