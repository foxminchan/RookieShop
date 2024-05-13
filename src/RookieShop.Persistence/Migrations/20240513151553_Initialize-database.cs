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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 13, 15, 15, 52, 235, DateTimeKind.Utc).AddTicks(6158)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 13, 15, 15, 52, 235, DateTimeKind.Utc).AddTicks(6410)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("f33ca7f5-2b66-440e-b22a-f15915e30b20"))
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
                    gender = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    account_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 13, 15, 15, 52, 236, DateTimeKind.Utc).AddTicks(2322)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 13, 15, 15, 52, 236, DateTimeKind.Utc).AddTicks(2514)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("e43f0c00-f305-439a-84f4-65832febdce3"))
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
                    status = table.Column<int>(type: "integer", nullable: false),
                    embedding = table.Column<Vector>(type: "vector(384)", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 13, 15, 15, 52, 247, DateTimeKind.Utc).AddTicks(757)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 13, 15, 15, 52, 247, DateTimeKind.Utc).AddTicks(1049)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("1b21a17f-35e5-49b1-b2a5-500361e922b6")),
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
                    payment_method = table.Column<int>(type: "integer", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 13, 15, 15, 52, 237, DateTimeKind.Utc).AddTicks(3716)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 13, 15, 15, 52, 237, DateTimeKind.Utc).AddTicks(3899)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("588e391c-adff-4162-9467-b952413e860d"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 13, 15, 15, 52, 237, DateTimeKind.Utc).AddTicks(54)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 13, 15, 15, 52, 237, DateTimeKind.Utc).AddTicks(251)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("b17844bc-e054-4470-902b-58c8a40eed64"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 13, 15, 15, 52, 246, DateTimeKind.Utc).AddTicks(3604)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 13, 15, 15, 52, 246, DateTimeKind.Utc).AddTicks(3897)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("92cd40f0-2d7b-4e4f-a9a3-c2dabe8ef1df"))
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
                    { new Guid("10631dc0-a122-4c80-a076-232dc773a19a"), new DateTime(2024, 5, 13, 15, 15, 52, 236, DateTimeKind.Utc).AddTicks(1120), "A book is a medium for recording information in the form of writing or images, typically composed of many pages bound together and protected by a cover.", "Book", new Guid("ecbefc65-3484-4d59-a303-c2612141cd62") },
                    { new Guid("1371f4f9-aac4-4462-9444-683be6372bc9"), new DateTime(2024, 5, 13, 15, 15, 52, 236, DateTimeKind.Utc).AddTicks(1144), "Jewellery consists of small decorative items worn for personal adornment, such as brooches, rings, necklaces, earrings, pendants, bracelets, and cufflinks.", "Jewelry", new Guid("d6775d58-046d-4cdc-b28a-38e6ea630267") },
                    { new Guid("142b1527-98f2-4b5a-bd69-67068dc602f1"), new DateTime(2024, 5, 13, 15, 15, 52, 236, DateTimeKind.Utc).AddTicks(1143), "Furniture refers to movable objects intended to support various human activities such as seating, eating, and sleeping.", "Furniture", new Guid("01bbe6d4-0cb0-4010-8872-78c81fd27dea") },
                    { new Guid("739c6c2f-0b6b-4015-bea1-02a20b6f6fd0"), new DateTime(2024, 5, 13, 15, 15, 52, 236, DateTimeKind.Utc).AddTicks(1130), "Electronics comprises the physics, engineering, technology and applications that deal with the emission, flow and control of electrons in vacuum and matter.", "Electronics", new Guid("3f61e3a3-fa45-4dd2-a8d2-ba9c4d83d2d4") },
                    { new Guid("ddcea197-7750-4ecc-b348-f1888e83cc8c"), new DateTime(2024, 5, 13, 15, 15, 52, 236, DateTimeKind.Utc).AddTicks(1128), "Clothes are items worn on the body. They are typically made of fabrics or textiles but over time have included garments made from animal skin or other thin sheets of materials put together.", "Clothes", new Guid("c9c4eb76-e145-4185-9db3-95c5253b6edc") }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "account_id", "created_date", "email", "gender", "is_deleted", "name", "phone", "version" },
                values: new object[,]
                {
                    { new Guid("137db4d3-cba5-45aa-85cd-ec742f113906"), null, new DateTime(2024, 5, 13, 15, 15, 52, 236, DateTimeKind.Utc).AddTicks(8933), "anna.johnson@gmail.com", 2, false, "Anna Johnson", "0123456789", new Guid("02fc2789-684a-443a-978c-dfef1151432f") },
                    { new Guid("594ee9f8-2d68-4c92-b71d-c86e04745901"), null, new DateTime(2024, 5, 13, 15, 15, 52, 236, DateTimeKind.Utc).AddTicks(8931), "maria.garcia@gmail.com", 2, false, "Maria Garcia", "0123456789", new Guid("7d2c83e4-49e7-4629-82d7-aa5f17e389b2") },
                    { new Guid("738011a0-4545-44fa-a6c5-6bacd3f7d248"), null, new DateTime(2024, 5, 13, 15, 15, 52, 236, DateTimeKind.Utc).AddTicks(8873), "john.doe@gmail.com", 1, false, "John Doe", "0123456789", new Guid("10ee790b-9b26-492b-a863-65dd920dc401") },
                    { new Guid("cb69688a-23eb-4d5d-a8bd-4b71d1dd359f"), null, new DateTime(2024, 5, 13, 15, 15, 52, 236, DateTimeKind.Utc).AddTicks(8892), "william.smith@gmail.com", 1, false, "William Smith", "0123456789", new Guid("4c7e8d06-a12c-4f07-bab0-6bc04a66bb96") }
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
