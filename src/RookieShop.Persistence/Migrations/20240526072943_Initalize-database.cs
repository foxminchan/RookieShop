using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RookieShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initalizedatabase : Migration
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 26, 7, 29, 42, 788, DateTimeKind.Utc).AddTicks(5283)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 26, 7, 29, 42, 788, DateTimeKind.Utc).AddTicks(5538)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("342540df-e719-4f7e-8142-896fd3c057e0"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 26, 7, 29, 42, 789, DateTimeKind.Utc).AddTicks(2069)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 26, 7, 29, 42, 789, DateTimeKind.Utc).AddTicks(2305)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("bee3dc2d-b9ef-4a18-b54e-17f6d7c52ebc"))
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
                    average_rating = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    total_reviews = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 26, 7, 29, 42, 795, DateTimeKind.Utc).AddTicks(1748)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 26, 7, 29, 42, 795, DateTimeKind.Utc).AddTicks(1990)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("48ae7fba-a60c-4f09-95ec-1477f6f65318")),
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 26, 7, 29, 42, 791, DateTimeKind.Utc).AddTicks(3000)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 26, 7, 29, 42, 791, DateTimeKind.Utc).AddTicks(3258)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("eb765674-9cb9-4a7b-9795-615f6e6192bc"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 26, 7, 29, 42, 790, DateTimeKind.Utc).AddTicks(154)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 26, 7, 29, 42, 790, DateTimeKind.Utc).AddTicks(368)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("af8e97c9-85b9-4d6c-9659-2c01e31894ee"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 5, 26, 7, 29, 42, 794, DateTimeKind.Utc).AddTicks(1361)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 5, 26, 7, 29, 42, 794, DateTimeKind.Utc).AddTicks(2058)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("b1b1ca74-c1a5-4460-8921-616c712b686c"))
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
                    { new Guid("05416004-bdec-48d2-8e7f-767873a5a228"), new DateTime(2024, 5, 26, 7, 29, 42, 789, DateTimeKind.Utc).AddTicks(791), "Stationery is a mass noun referring to commercially manufactured writing materials, including cut paper, envelopes, writing implements, continuous form paper, and other office supplies.", "Stationery", new Guid("93af261f-b55e-49a1-903a-33a1ffda21ec") },
                    { new Guid("361c599c-138b-4cce-92a6-a85cc39678c8"), new DateTime(2024, 5, 26, 7, 29, 42, 789, DateTimeKind.Utc).AddTicks(773), "A toy is an item that is used in play, especially one designed for such use. Playing with toys can be an enjoyable means of training young children for life in society.", "Toys", new Guid("b3c83e68-38ba-4fde-84eb-e9987de0c5b4") },
                    { new Guid("447e4b38-8996-4763-aa81-f43eb8b5d440"), new DateTime(2024, 5, 26, 7, 29, 42, 789, DateTimeKind.Utc).AddTicks(766), "A book is a medium for recording information in the form of writing or images, typically composed of many pages bound together and protected by a cover.", "Books", new Guid("4102abec-302c-4f9a-bdce-29fca05adae5") },
                    { new Guid("47493803-5737-4621-b29e-ae5a8b0e1ce0"), new DateTime(2024, 5, 26, 7, 29, 42, 789, DateTimeKind.Utc).AddTicks(776), "A comic book, also called comic magazine or (in the United Kingdom and Ireland) simply comic, is a publication that consists of comics art in the form of sequential juxtaposed panels that represent individual scenes.", "Comics", new Guid("fbaf7758-5bb0-441f-9d39-5672dc853950") },
                    { new Guid("b8e91b58-7158-45fa-88b5-96fdac4dcbb9"), new DateTime(2024, 5, 26, 7, 29, 42, 789, DateTimeKind.Utc).AddTicks(787), "Artwork is a term that describes art that is created to be appreciated for its own sake. It generally refers to visual art, such as paintings, sculptures, and printmaking.", "Artworks", new Guid("f389691a-1562-4ad4-8287-f2ea9fd1a257") },
                    { new Guid("f7636d3b-7f3e-4040-9beb-73f860041310"), new DateTime(2024, 5, 26, 7, 29, 42, 789, DateTimeKind.Utc).AddTicks(789), "A souvenir is an object that is kept as a reminder of a person, place, or event. The object itself may have intrinsic value, or be a symbol of experience.", "Souvenirs", new Guid("e20e02eb-a112-421c-b37e-5545c4d6aaf9") }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "account_id", "created_date", "email", "gender", "is_deleted", "name", "phone", "version" },
                values: new object[,]
                {
                    { new Guid("12da5fa6-d57c-4272-b463-06d08c502138"), null, new DateTime(2024, 5, 26, 7, 29, 42, 789, DateTimeKind.Utc).AddTicks(8988), "nguyenxuannhan.dev@gmail.com", (byte)1, false, "Fox Min Chan", "0123456789", new Guid("863d6d38-b255-4650-9017-135f59fb0f32") },
                    { new Guid("eebda025-0380-4581-92af-57590a790160"), new Guid("7055bbfe-25c6-4b33-98cd-fc2b9fb4bb1a"), new DateTime(2024, 5, 26, 7, 29, 42, 789, DateTimeKind.Utc).AddTicks(8972), "nguyenxuannhan407@gmail.com", (byte)1, false, "Nhan Nguyen", "0123456789", new Guid("0f3dcc40-38e5-4bf4-9ab7-96505fe666ba") }
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
