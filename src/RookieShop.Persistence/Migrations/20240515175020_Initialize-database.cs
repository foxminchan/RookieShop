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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 235, DateTimeKind.Utc).AddTicks(1469)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 236, DateTimeKind.Utc).AddTicks(4175)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("5ae072f4-2894-473b-8bd3-33e23a72415e"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 246, DateTimeKind.Utc).AddTicks(3350)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 246, DateTimeKind.Utc).AddTicks(4029)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("3ff89c10-016d-44d0-84b3-28e18873f45e"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 277, DateTimeKind.Utc).AddTicks(193)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 277, DateTimeKind.Utc).AddTicks(1034)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("79f84530-e1ae-4942-a178-c36a7fc53326")),
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
                    order_status = table.Column<byte>(type: "smallint", nullable: false),
                    payment_method = table.Column<byte>(type: "smallint", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 255, DateTimeKind.Utc).AddTicks(5679)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 255, DateTimeKind.Utc).AddTicks(6347)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("06d257b6-d97c-4188-94e9-8147558582b0"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 249, DateTimeKind.Utc).AddTicks(4153)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 249, DateTimeKind.Utc).AddTicks(4752)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("f72341f8-0bcf-4981-9673-4fe41091ee9c"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 274, DateTimeKind.Utc).AddTicks(1455)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 274, DateTimeKind.Utc).AddTicks(1978)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("4a763110-16c7-4eb8-861e-405871622619"))
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
                    { new Guid("1b0fe880-82f2-4dad-b2cf-3ed268c990c9"), new DateTime(2024, 5, 15, 17, 50, 20, 245, DateTimeKind.Utc).AddTicks(7861), "Jewellery consists of small decorative items worn for personal adornment, such as brooches, rings, necklaces, earrings, pendants, bracelets, and cuff-links.", "Jewelry", new Guid("8ca0ad1a-ddd9-4d87-ada6-57fe02b84e6c") },
                    { new Guid("2facad51-f7e0-4b61-b905-9e364c756ea1"), new DateTime(2024, 5, 15, 17, 50, 20, 245, DateTimeKind.Utc).AddTicks(7859), "Furniture refers to movable objects intended to support various human activities such as seating, eating, and sleeping.", "Furniture", new Guid("4308f421-49c8-4a3a-a77d-b4b574ab6c21") },
                    { new Guid("50436dab-1c7a-4373-968f-4b19d880fca0"), new DateTime(2024, 5, 15, 17, 50, 20, 245, DateTimeKind.Utc).AddTicks(7790), "Clothes are items worn on the body. They are typically made of fabrics or textiles but over time have included garments made from animal skin or other thin sheets of materials put together.", "Clothes", new Guid("9791118c-63bc-4310-81b2-df92c8b27f09") },
                    { new Guid("5ffd88a8-a02c-49d9-9088-f58488fa544a"), new DateTime(2024, 5, 15, 17, 50, 20, 245, DateTimeKind.Utc).AddTicks(6967), "A book is a medium for recording information in the form of writing or images, typically composed of many pages bound together and protected by a cover.", "Book", new Guid("ec224a40-dd38-423c-9ab1-cc153f634fa9") },
                    { new Guid("61227d05-8f2d-47aa-9cd0-41ad0c71c33d"), new DateTime(2024, 5, 15, 17, 50, 20, 245, DateTimeKind.Utc).AddTicks(7843), "Electronics comprises the physics, engineering, technology and applications that deal with the emission, flow and control of electrons in vacuum and matter.", "Electronics", new Guid("3718a19b-df67-47fb-976a-40f760be13c8") },
                    { new Guid("75b12d43-3217-4747-a2d0-64a3e556b961"), new DateTime(2024, 5, 15, 17, 50, 20, 245, DateTimeKind.Utc).AddTicks(7867), "A shoe is an item of footwear intended to protect and comfort the human foot. Shoes", "Shoes", new Guid("debfeed3-d8d6-404b-9744-d603116701b1") },
                    { new Guid("d9328b75-687c-4e11-b29e-cfcb6e803c2c"), new DateTime(2024, 5, 15, 17, 50, 20, 245, DateTimeKind.Utc).AddTicks(7869), "Sport includes all forms of competitive physical activity or games which, through casual or organized participation, at least in part aim to use, maintain or improve physical ability and skills while providing enjoyment to participants, and in some cases, entertainment for spectators.", "Sport", new Guid("3c1a1a94-b6fc-44f2-a1a0-3aaa26a4cbd0") }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "account_id", "created_date", "email", "gender", "is_deleted", "name", "phone", "version" },
                values: new object[,]
                {
                    { new Guid("3b53f8c3-a7c4-4830-82ae-bb06e198e1f0"), null, new DateTime(2024, 5, 15, 17, 50, 20, 248, DateTimeKind.Utc).AddTicks(3447), "william.smith@gmail.com", (byte)1, false, "William Smith", "0123456789", new Guid("9fe55392-407d-46c1-a668-370cc6a2a859") },
                    { new Guid("7fc6f693-5012-4019-af59-25261473a7a7"), new Guid("e5255692-c91f-43ba-937c-059895fd67a2"), new DateTime(2024, 5, 15, 17, 50, 20, 248, DateTimeKind.Utc).AddTicks(4119), "nguyenxuannhan.dev@gmail.com", (byte)1, false, "Fox Min Chan", "0123456789", new Guid("d75f50d2-1722-4f35-9973-20146f9aaef0") },
                    { new Guid("9b158899-216f-443a-b961-5f4213f7269b"), null, new DateTime(2024, 5, 15, 17, 50, 20, 248, DateTimeKind.Utc).AddTicks(2662), "john.doe@gmail.com", (byte)1, false, "John Doe", "0123456789", new Guid("bb408220-a446-4e32-b649-e5592981836c") },
                    { new Guid("adbebe75-3aed-42ee-b08e-f64981f10ddc"), null, new DateTime(2024, 5, 15, 17, 50, 20, 248, DateTimeKind.Utc).AddTicks(3719), "anna.johnson@gmail.com", (byte)2, false, "Anna Johnson", "0123456789", new Guid("95cce9a6-8069-4654-9458-829efee23154") },
                    { new Guid("c8f6195d-e70c-4806-b873-ed9d40973982"), new Guid("7055bbfe-25c6-4b33-98cd-fc2b9fb4bb1a"), new DateTime(2024, 5, 15, 17, 50, 20, 248, DateTimeKind.Utc).AddTicks(3722), "nguyenxuannhan407@gmail.com", (byte)1, false, "Nhan Nguyen", "0123456789", new Guid("f570833e-dd29-49fc-a3f7-19f27a081c43") },
                    { new Guid("fe6986eb-208f-42b9-8b7b-553afe2c125f"), null, new DateTime(2024, 5, 15, 17, 50, 20, 248, DateTimeKind.Utc).AddTicks(3711), "maria.garcia@gmail.com", (byte)2, false, "Maria Garcia", "0123456789", new Guid("721ccb6e-4d28-4216-b8c3-a75536916728") }
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
