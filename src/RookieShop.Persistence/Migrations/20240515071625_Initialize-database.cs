using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 7, 16, 24, 694, DateTimeKind.Utc).AddTicks(9469)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 7, 16, 24, 696, DateTimeKind.Utc).AddTicks(1999)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("e0de071f-338e-4fd3-865f-c825b0526481"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 7, 16, 24, 705, DateTimeKind.Utc).AddTicks(6967)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 7, 16, 24, 705, DateTimeKind.Utc).AddTicks(7512)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("de0d5421-c7c0-4e19-b173-fad59187821e"))
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
                    image_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 7, 16, 24, 734, DateTimeKind.Utc).AddTicks(9739)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 7, 16, 24, 735, DateTimeKind.Utc).AddTicks(502)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("a346cff4-4623-4a77-b36b-65fee11bc169")),
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 7, 16, 24, 714, DateTimeKind.Utc).AddTicks(4388)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 7, 16, 24, 714, DateTimeKind.Utc).AddTicks(4876)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("ce33cab6-52c4-4e6f-b9c9-dd0a66b556f1"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 7, 16, 24, 709, DateTimeKind.Utc).AddTicks(409)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 7, 16, 24, 709, DateTimeKind.Utc).AddTicks(967)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("0dc72ce5-53ac-4893-9e14-258816e3260b"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 7, 16, 24, 732, DateTimeKind.Utc).AddTicks(1880)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 7, 16, 24, 732, DateTimeKind.Utc).AddTicks(2399)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("0df92617-82dc-4b72-85ec-6ed0cd10f64a"))
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
                    { new Guid("2ca40d95-5654-4fe2-afb2-9164a232e0cd"), new DateTime(2024, 5, 15, 7, 16, 24, 704, DateTimeKind.Utc).AddTicks(9912), "A book is a medium for recording information in the form of writing or images, typically composed of many pages bound together and protected by a cover.", "Book", new Guid("57f105a6-d564-4f21-ab99-88b6143a0dea") },
                    { new Guid("77756616-81de-4722-847a-1c9a0419177e"), new DateTime(2024, 5, 15, 7, 16, 24, 705, DateTimeKind.Utc).AddTicks(1107), "Jewellery consists of small decorative items worn for personal adornment, such as brooches, rings, necklaces, earrings, pendants, bracelets, and cufflinks.", "Jewelry", new Guid("56aed567-fb14-4fbb-86e9-3ca00e4254fc") },
                    { new Guid("88e21030-f59d-4a7c-aaad-1f3fd144dc7c"), new DateTime(2024, 5, 15, 7, 16, 24, 705, DateTimeKind.Utc).AddTicks(1102), "Electronics comprises the physics, engineering, technology and applications that deal with the emission, flow and control of electrons in vacuum and matter.", "Electronics", new Guid("1b32bdd8-fcb0-411a-90fc-0760b6b46f52") },
                    { new Guid("b24c1344-0105-4153-9357-cfd978231347"), new DateTime(2024, 5, 15, 7, 16, 24, 705, DateTimeKind.Utc).AddTicks(1037), "Clothes are items worn on the body. They are typically made of fabrics or textiles but over time have included garments made from animal skin or other thin sheets of materials put together.", "Clothes", new Guid("ad26a05e-1ba8-4e57-8581-9dceefc69cc3") },
                    { new Guid("e909ef55-2792-4ec1-b8b7-9cd5b7718fad"), new DateTime(2024, 5, 15, 7, 16, 24, 705, DateTimeKind.Utc).AddTicks(1105), "Furniture refers to movable objects intended to support various human activities such as seating, eating, and sleeping.", "Furniture", new Guid("fd804247-23f1-4d97-b3ff-73389aa1eef2") }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "account_id", "created_date", "email", "gender", "is_deleted", "name", "phone", "version" },
                values: new object[,]
                {
                    { new Guid("14879784-e536-4da9-a216-3cc4391a2400"), null, new DateTime(2024, 5, 15, 7, 16, 24, 707, DateTimeKind.Utc).AddTicks(9711), "maria.garcia@gmail.com", (byte)2, false, "Maria Garcia", "0123456789", new Guid("81775316-dcf1-4e60-918c-3b73cc7d43b3") },
                    { new Guid("613d2282-40c6-49ca-a440-9ec8273dd780"), null, new DateTime(2024, 5, 15, 7, 16, 24, 707, DateTimeKind.Utc).AddTicks(9642), "william.smith@gmail.com", (byte)1, false, "William Smith", "0123456789", new Guid("67f63d8d-2378-4d13-a6d0-6b25d3648ccb") },
                    { new Guid("8a572fee-d4b6-401e-8855-5326e587eb47"), null, new DateTime(2024, 5, 15, 7, 16, 24, 707, DateTimeKind.Utc).AddTicks(8918), "john.doe@gmail.com", (byte)1, false, "John Doe", "0123456789", new Guid("abe60d87-b92a-42f7-9d30-92c1e68712bc") },
                    { new Guid("fc4d736b-1cb8-4b95-bb3c-d41850af29b4"), null, new DateTime(2024, 5, 15, 7, 16, 24, 707, DateTimeKind.Utc).AddTicks(9715), "anna.johnson@gmail.com", (byte)2, false, "Anna Johnson", "0123456789", new Guid("871def9c-f944-4c2c-8434-421b1a074c13") }
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
