using System;
using Microsoft.EntityFrameworkCore.Migrations;
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
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 6, 8, 16, 0, 16, 704, DateTimeKind.Utc).AddTicks(4226)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 6, 8, 16, 0, 16, 704, DateTimeKind.Utc).AddTicks(4626)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("bf570dc2-41e6-4f6a-9383-c1d084c32b84"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 6, 8, 16, 0, 16, 705, DateTimeKind.Utc).AddTicks(2354)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 6, 8, 16, 0, 16, 705, DateTimeKind.Utc).AddTicks(2590)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("0c851886-6ca3-4901-afb1-3a9c232eb1af"))
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
                    embedding = table.Column<Vector>(type: "vector(384)", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 6, 8, 16, 0, 16, 712, DateTimeKind.Utc).AddTicks(5951)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 6, 8, 16, 0, 16, 712, DateTimeKind.Utc).AddTicks(6265)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("1fd494dd-341f-46ca-a3fb-b4c8f62acd79")),
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 6, 8, 16, 0, 16, 708, DateTimeKind.Utc).AddTicks(949)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 6, 8, 16, 0, 16, 708, DateTimeKind.Utc).AddTicks(1311)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("96d2ce25-2ba4-478b-bd4d-59e5bed0132d"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 6, 8, 16, 0, 16, 706, DateTimeKind.Utc).AddTicks(2389)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 6, 8, 16, 0, 16, 706, DateTimeKind.Utc).AddTicks(2698)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("34b29e8f-3924-4449-9989-9a197a0f8370"))
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
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 6, 8, 16, 0, 16, 711, DateTimeKind.Utc).AddTicks(5326)),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2024, 6, 8, 16, 0, 16, 711, DateTimeKind.Utc).AddTicks(5612)),
                    version = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("7f826faf-581f-456c-b9b7-d561f96f088c"))
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
                columns: new[] { "id", "created_date", "description", "is_deleted", "name", "version" },
                values: new object[,]
                {
                    { new Guid("4736ffeb-cfce-4f68-b527-b9f6d5444f7e"), new DateTime(2024, 6, 8, 16, 0, 16, 705, DateTimeKind.Utc).AddTicks(913), "A toy is an item that is used in play, especially one designed for such use. Playing with toys can be an enjoyable means of training young children for life in society.", false, "Toys", new Guid("9002d6d4-678a-458e-9aae-ecb11da618f6") },
                    { new Guid("52bfc10c-7f88-4105-a002-55197ff308ce"), new DateTime(2024, 6, 8, 16, 0, 16, 705, DateTimeKind.Utc).AddTicks(932), "A souvenir is an object that is kept as a reminder of a person, place, or event. The object itself may have intrinsic value, or be a symbol of experience.", false, "Souvenirs", new Guid("bfb9afe1-9c8a-4c1c-b19b-482755ccc16d") },
                    { new Guid("624dcddd-9b23-47e7-8e58-54fb92ffd489"), new DateTime(2024, 6, 8, 16, 0, 16, 705, DateTimeKind.Utc).AddTicks(929), "Artwork is a term that describes art that is created to be appreciated for its own sake. It generally refers to visual art, such as paintings, sculptures, and printmaking.", false, "Artworks", new Guid("d27c9645-c53c-4ee7-b694-8031f1004886") },
                    { new Guid("8d7d55f7-cf10-42d3-936f-7cb6150130d3"), new DateTime(2024, 6, 8, 16, 0, 16, 705, DateTimeKind.Utc).AddTicks(895), "A book is a medium for recording information in the form of writing or images, typically composed of many pages bound together and protected by a cover.", false, "Books", new Guid("1e2c7f60-7dcc-421a-816e-3681209c2fa1") },
                    { new Guid("8eebe4a6-5e66-4655-91a6-b35d50edf167"), new DateTime(2024, 6, 8, 16, 0, 16, 705, DateTimeKind.Utc).AddTicks(935), "Stationery is a mass noun referring to commercially manufactured writing materials, including cut paper, envelopes, writing implements, continuous form paper, and other office supplies.", false, "Stationery", new Guid("344ca78f-a129-4455-937c-a9254b2ecd85") },
                    { new Guid("9cf92ba3-2382-4ef4-9899-5d497cce0efe"), new DateTime(2024, 6, 8, 16, 0, 16, 705, DateTimeKind.Utc).AddTicks(927), "A comic book, also called comic magazine or (in the United Kingdom and Ireland) simply comic, is a publication that consists of comics art in the form of sequential juxtaposed panels that represent individual scenes.", false, "Comics", new Guid("e7cfc774-d83a-4ef2-876b-0f9d786a6951") }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "account_id", "created_date", "email", "gender", "is_deleted", "name", "phone", "version" },
                values: new object[,]
                {
                    { new Guid("3906a8e8-f63c-4172-991c-3ec2c86a1dc3"), new Guid("7055bbfe-25c6-4b33-98cd-fc2b9fb4bb1a"), new DateTime(2024, 6, 8, 16, 0, 16, 706, DateTimeKind.Utc).AddTicks(1003), "nguyenxuannhan407@gmail.com", (byte)1, false, "Nhan Nguyen", "0123456789", new Guid("4c4dbc31-e498-4c38-9fa1-97318e29e737") },
                    { new Guid("63ccb9b4-daeb-4e12-a6ed-7a8421cbf6a5"), null, new DateTime(2024, 6, 8, 16, 0, 16, 706, DateTimeKind.Utc).AddTicks(1025), "nguyenxuannhan.dev@gmail.com", (byte)1, false, "Fox Min Chan", "0123456789", new Guid("61618209-9dd9-442b-815f-669419835118") }
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
