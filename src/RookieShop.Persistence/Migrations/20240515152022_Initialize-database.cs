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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 15, 20, 21, 128, DateTimeKind.Utc).AddTicks(6798)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 15, 20, 21, 128, DateTimeKind.Utc).AddTicks(7190)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("8db3fe99-28e8-4458-9522-2a8b9a9601e1"))
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
                    account_id = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 15, 20, 21, 129, DateTimeKind.Utc).AddTicks(6281)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 15, 20, 21, 129, DateTimeKind.Utc).AddTicks(6508)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("ef8a319c-6857-413c-b3d8-44af7985585c"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 15, 20, 21, 138, DateTimeKind.Utc).AddTicks(7808)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 15, 20, 21, 138, DateTimeKind.Utc).AddTicks(8171)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("4668d09a-82e4-435c-a08e-008bbfd46cca")),
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 15, 20, 21, 132, DateTimeKind.Utc).AddTicks(8528)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 15, 20, 21, 132, DateTimeKind.Utc).AddTicks(8847)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("f869b873-f442-489c-a0fe-7bdd0f111e71"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 15, 20, 21, 130, DateTimeKind.Utc).AddTicks(8740)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 15, 20, 21, 130, DateTimeKind.Utc).AddTicks(9132)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("2643b8ba-4d75-417e-8f66-0210a92c1e73"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 15, 20, 21, 137, DateTimeKind.Utc).AddTicks(5947)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 15, 20, 21, 137, DateTimeKind.Utc).AddTicks(6247)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("f965bcf6-ba8f-47cc-8376-c99411430f28"))
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
                    { new Guid("23498035-cecd-4342-ad82-80eebcfd0120"), new DateTime(2024, 5, 15, 15, 20, 21, 129, DateTimeKind.Utc).AddTicks(4878), "Furniture refers to movable objects intended to support various human activities such as seating, eating, and sleeping.", "Furniture", new Guid("d56712e6-2c1c-4878-a60c-e30dc7c8f3b6") },
                    { new Guid("2e7ff04d-b5ed-47b0-97bb-fdefe48b86e8"), new DateTime(2024, 5, 15, 15, 20, 21, 129, DateTimeKind.Utc).AddTicks(4889), "Jewellery consists of small decorative items worn for personal adornment, such as brooches, rings, necklaces, earrings, pendants, bracelets, and cufflinks.", "Jewelry", new Guid("ee1b3192-7275-4d82-926a-f3a58809a3ab") },
                    { new Guid("3205faa6-60f8-4f63-a9f5-9052d4066cda"), new DateTime(2024, 5, 15, 15, 20, 21, 129, DateTimeKind.Utc).AddTicks(4863), "A book is a medium for recording information in the form of writing or images, typically composed of many pages bound together and protected by a cover.", "Book", new Guid("5db178a6-f534-4b4d-af1f-04e453813304") },
                    { new Guid("b8fba286-52bf-4912-b61b-a092ac693826"), new DateTime(2024, 5, 15, 15, 20, 21, 129, DateTimeKind.Utc).AddTicks(4876), "Electronics comprises the physics, engineering, technology and applications that deal with the emission, flow and control of electrons in vacuum and matter.", "Electronics", new Guid("a2e6f8a7-7e2d-4ebe-84db-384ef531d7cb") },
                    { new Guid("f84e9d02-91b0-463a-99c1-9859737c16e4"), new DateTime(2024, 5, 15, 15, 20, 21, 129, DateTimeKind.Utc).AddTicks(4873), "Clothes are items worn on the body. They are typically made of fabrics or textiles but over time have included garments made from animal skin or other thin sheets of materials put together.", "Clothes", new Guid("15089d0c-3c01-43e0-b1b8-834c48c024ae") }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "account_id", "created_date", "email", "gender", "is_deleted", "name", "phone", "version" },
                values: new object[,]
                {
                    { new Guid("2ca903a3-5177-41aa-9d98-4cc29d035eb5"), null, new DateTime(2024, 5, 15, 15, 20, 21, 130, DateTimeKind.Utc).AddTicks(6900), "maria.garcia@gmail.com", (byte)2, false, "Maria Garcia", "0123456789", new Guid("1812e9eb-ff70-42d2-b8ec-cac2249b64e9") },
                    { new Guid("35d04043-0998-491c-ab15-8e8e7b1372d6"), null, new DateTime(2024, 5, 15, 15, 20, 21, 130, DateTimeKind.Utc).AddTicks(6902), "anna.johnson@gmail.com", (byte)2, false, "Anna Johnson", "0123456789", new Guid("8dc1537a-d64a-46f8-a60a-5c7e6f65a1e6") },
                    { new Guid("979fb99c-b8ea-45d5-9c6f-c0c7132e2e35"), null, new DateTime(2024, 5, 15, 15, 20, 21, 130, DateTimeKind.Utc).AddTicks(6896), "william.smith@gmail.com", (byte)1, false, "William Smith", "0123456789", new Guid("bd62d3fb-30b2-4a54-8f0a-b42e94ba18fe") },
                    { new Guid("ed373b7f-772a-4a97-8617-f9a8f1603c48"), null, new DateTime(2024, 5, 15, 15, 20, 21, 130, DateTimeKind.Utc).AddTicks(6884), "john.doe@gmail.com", (byte)1, false, "John Doe", "0123456789", new Guid("4d02489a-069d-4a46-a098-7506bb0823b5") }
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
