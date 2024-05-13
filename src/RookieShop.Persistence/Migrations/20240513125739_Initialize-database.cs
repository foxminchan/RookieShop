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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 13, 12, 57, 37, 809, DateTimeKind.Utc).AddTicks(2410)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 13, 12, 57, 37, 809, DateTimeKind.Utc).AddTicks(2655)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("54b666a5-2cc4-4f31-a9ea-f0eed1ff13e2"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 13, 12, 57, 37, 809, DateTimeKind.Utc).AddTicks(9861)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 13, 12, 57, 37, 810, DateTimeKind.Utc).AddTicks(199)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("46db7071-1160-493f-b113-fa336b9d9dbd"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 13, 12, 57, 37, 813, DateTimeKind.Utc).AddTicks(9024)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 13, 12, 57, 37, 813, DateTimeKind.Utc).AddTicks(9242)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("11c67b7c-e6a2-436d-b653-ac40f97d660f")),
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
                    payment_method = table.Column<int>(type: "integer", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 13, 12, 57, 37, 811, DateTimeKind.Utc).AddTicks(3024)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 13, 12, 57, 37, 811, DateTimeKind.Utc).AddTicks(3249)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("dc4a772c-4042-41b1-b681-94f97894590b"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 13, 12, 57, 37, 810, DateTimeKind.Utc).AddTicks(8920)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 13, 12, 57, 37, 810, DateTimeKind.Utc).AddTicks(9154)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("70115ce1-a876-4846-b5b7-b537c6c29bf7"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 13, 12, 57, 37, 813, DateTimeKind.Utc).AddTicks(2100)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 13, 12, 57, 37, 813, DateTimeKind.Utc).AddTicks(2355)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("e5acdecb-0507-4ecc-9452-1c1398c8b79b"))
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
                    { new Guid("29b84fb9-c9d3-412a-a206-27b344567f64"), new DateTime(2024, 5, 13, 12, 57, 37, 809, DateTimeKind.Utc).AddTicks(7902), "A book is a medium for recording information in the form of writing or images, typically composed of many pages bound together and protected by a cover.", "Book", new Guid("8ce3a6c9-52cd-447a-8ebe-87250c33828e") },
                    { new Guid("39113ab0-0d56-4f86-95e7-e289e2286829"), new DateTime(2024, 5, 13, 12, 57, 37, 809, DateTimeKind.Utc).AddTicks(7913), "Electronics comprises the physics, engineering, technology and applications that deal with the emission, flow and control of electrons in vacuum and matter.", "Electronics", new Guid("358ccba5-5b5c-4248-a567-39f1da8e88aa") },
                    { new Guid("a4f20a74-77e6-4b85-9faf-822ce108bda7"), new DateTime(2024, 5, 13, 12, 57, 37, 809, DateTimeKind.Utc).AddTicks(7910), "Clothes are items worn on the body. They are typically made of fabrics or textiles but over time have included garments made from animal skin or other thin sheets of materials put together.", "Clothes", new Guid("7f4337a6-f561-4056-b705-14e3ebf2543b") },
                    { new Guid("aa3b2b9d-c57b-44f3-bfb9-f0587b91133b"), new DateTime(2024, 5, 13, 12, 57, 37, 809, DateTimeKind.Utc).AddTicks(7919), "Jewellery consists of small decorative items worn for personal adornment, such as brooches, rings, necklaces, earrings, pendants, bracelets, and cufflinks.", "Jewelry", new Guid("41500727-7ab7-4a8d-b54b-11971b5a9749") },
                    { new Guid("e7987a87-255f-44d0-987a-ff257468c9df"), new DateTime(2024, 5, 13, 12, 57, 37, 809, DateTimeKind.Utc).AddTicks(7915), "Furniture refers to movable objects intended to support various human activities such as seating, eating, and sleeping.", "Furniture", new Guid("f0d21731-10ce-4697-b4e7-72357eaa5cd4") }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "account_id", "created_date", "email", "gender", "is_deleted", "name", "phone", "version" },
                values: new object[,]
                {
                    { new Guid("1a889320-c84b-45f0-b515-f1887d85da33"), null, new DateTime(2024, 5, 13, 12, 57, 37, 810, DateTimeKind.Utc).AddTicks(7625), "john.doe@gmail.com", 1, false, "John Doe", "0123456789", new Guid("fb8b311e-2bdb-448e-82da-d2e6e9d110e3") },
                    { new Guid("5e2d369d-b42f-40fd-8a33-5ae7eeb96a4b"), null, new DateTime(2024, 5, 13, 12, 57, 37, 810, DateTimeKind.Utc).AddTicks(7648), "anna.johnson@gmail.com", 2, false, "Anna Johnson", "0123456789", new Guid("cb371b5a-d3d4-4731-aa49-6d3d920bda00") },
                    { new Guid("a0189f9f-ea41-4043-8bbc-ddae0bbcf4e8"), null, new DateTime(2024, 5, 13, 12, 57, 37, 810, DateTimeKind.Utc).AddTicks(7646), "maria.garcia@gmail.com", 2, false, "Maria Garcia", "0123456789", new Guid("0889f6ae-b1a7-47ac-9c5a-72a600b4008d") },
                    { new Guid("f14d777d-e7bb-41f5-851a-e9aee7630918"), null, new DateTime(2024, 5, 13, 12, 57, 37, 810, DateTimeKind.Utc).AddTicks(7642), "william.smith@gmail.com", 1, false, "William Smith", "0123456789", new Guid("e1900009-605c-46ec-8986-93330d29bebb") }
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
