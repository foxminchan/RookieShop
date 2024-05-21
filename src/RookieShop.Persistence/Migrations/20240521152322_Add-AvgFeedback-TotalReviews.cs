using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RookieShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAvgFeedbackTotalReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("1b0fe880-82f2-4dad-b2cf-3ed268c990c9"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("2facad51-f7e0-4b61-b905-9e364c756ea1"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("50436dab-1c7a-4373-968f-4b19d880fca0"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("5ffd88a8-a02c-49d9-9088-f58488fa544a"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("61227d05-8f2d-47aa-9cd0-41ad0c71c33d"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("75b12d43-3217-4747-a2d0-64a3e556b961"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("d9328b75-687c-4e11-b29e-cfcb6e803c2c"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("3b53f8c3-a7c4-4830-82ae-bb06e198e1f0"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("7fc6f693-5012-4019-af59-25261473a7a7"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("9b158899-216f-443a-b961-5f4213f7269b"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("adbebe75-3aed-42ee-b08e-f64981f10ddc"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("c8f6195d-e70c-4806-b873-ed9d40973982"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("fe6986eb-208f-42b9-8b7b-553afe2c125f"));

            migrationBuilder.AlterColumn<Guid>(
                name: "version",
                table: "products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("e36e46d5-b90e-4829-a5c6-8cd4e504ec63"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("79f84530-e1ae-4942-a178-c36a7fc53326"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "products",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 434, DateTimeKind.Utc).AddTicks(5522),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 277, DateTimeKind.Utc).AddTicks(1034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 434, DateTimeKind.Utc).AddTicks(5000),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 277, DateTimeKind.Utc).AddTicks(193));

            migrationBuilder.AddColumn<double>(
                name: "average_rating",
                table: "products",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "total_reviews",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "version",
                table: "orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6b1007d2-1ef8-4cf6-9d0c-fb836ce6631c"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("06d257b6-d97c-4188-94e9-8147558582b0"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "orders",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 414, DateTimeKind.Utc).AddTicks(2969),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 255, DateTimeKind.Utc).AddTicks(6347));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 414, DateTimeKind.Utc).AddTicks(2442),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 255, DateTimeKind.Utc).AddTicks(5679));

            migrationBuilder.AlterColumn<Guid>(
                name: "version",
                table: "order_details",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("ff9b63a8-8ab1-46c5-87b9-1caadac55d54"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("4a763110-16c7-4eb8-861e-405871622619"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "order_details",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 431, DateTimeKind.Utc).AddTicks(9719),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 274, DateTimeKind.Utc).AddTicks(1978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "order_details",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 431, DateTimeKind.Utc).AddTicks(9255),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 274, DateTimeKind.Utc).AddTicks(1455));

            migrationBuilder.AlterColumn<Guid>(
                name: "version",
                table: "feedbacks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("e534c3f5-92fc-4991-b667-b5443f662c1c"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("f72341f8-0bcf-4981-9673-4fe41091ee9c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "feedbacks",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 408, DateTimeKind.Utc).AddTicks(7332),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 249, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "feedbacks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 408, DateTimeKind.Utc).AddTicks(6794),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 249, DateTimeKind.Utc).AddTicks(4153));

            migrationBuilder.AlterColumn<Guid>(
                name: "version",
                table: "customers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("46a006ad-98ee-4a7a-97e9-53f0d5896cfd"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("3ff89c10-016d-44d0-84b3-28e18873f45e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "customers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 406, DateTimeKind.Utc).AddTicks(2918),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 246, DateTimeKind.Utc).AddTicks(4029));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 406, DateTimeKind.Utc).AddTicks(2411),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 246, DateTimeKind.Utc).AddTicks(3350));

            migrationBuilder.AlterColumn<Guid>(
                name: "version",
                table: "categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("d8ad0b46-91b5-43c2-bf26-b22a4c5a1165"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("5ae072f4-2894-473b-8bd3-33e23a72415e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "categories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 396, DateTimeKind.Utc).AddTicks(8707),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 236, DateTimeKind.Utc).AddTicks(4175));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 395, DateTimeKind.Utc).AddTicks(6063),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 235, DateTimeKind.Utc).AddTicks(1469));

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "created_date", "description", "name", "version" },
                values: new object[,]
                {
                    { new Guid("1b1637d7-9177-4ba9-bac5-cc297973098f"), new DateTime(2024, 5, 21, 15, 23, 20, 405, DateTimeKind.Utc).AddTicks(7229), "Electronics comprises the physics, engineering, technology and applications that deal with the emission, flow and control of electrons in vacuum and matter.", "Electronics", new Guid("09083972-1d9b-4692-a65b-0cac146d920c") },
                    { new Guid("5bd7ae95-4ea7-4d61-a6fb-da2442383dd5"), new DateTime(2024, 5, 21, 15, 23, 20, 405, DateTimeKind.Utc).AddTicks(7243), "A shoe is an item of footwear intended to protect and comfort the human foot. Shoes", "Shoes", new Guid("48990606-4993-49c7-8151-cd7afd8487ca") },
                    { new Guid("6d8df0fe-b0f9-4523-9f2b-d194dfca61e3"), new DateTime(2024, 5, 21, 15, 23, 20, 405, DateTimeKind.Utc).AddTicks(7245), "Sport includes all forms of competitive physical activity or games which, through casual or organized participation, at least in part aim to use, maintain or improve physical ability and skills while providing enjoyment to participants, and in some cases, entertainment for spectators.", "Sport", new Guid("2abb2a0a-f27b-4a63-9f0f-c90a30a1dc2c") },
                    { new Guid("a6a2065d-df2a-42e7-a0f8-a26be4d4c7ad"), new DateTime(2024, 5, 21, 15, 23, 20, 405, DateTimeKind.Utc).AddTicks(7232), "Furniture refers to movable objects intended to support various human activities such as seating, eating, and sleeping.", "Furniture", new Guid("dddd0a97-de43-442e-b288-5177c823973e") },
                    { new Guid("f12dfb9b-1b6c-4302-8906-a0f262e6f280"), new DateTime(2024, 5, 21, 15, 23, 20, 405, DateTimeKind.Utc).AddTicks(6411), "A book is a medium for recording information in the form of writing or images, typically composed of many pages bound together and protected by a cover.", "Book", new Guid("cee31f65-eea0-45ef-bc0a-dace974996b3") },
                    { new Guid("f7285e91-9076-423e-98e9-30d7138ac72e"), new DateTime(2024, 5, 21, 15, 23, 20, 405, DateTimeKind.Utc).AddTicks(7238), "Jewellery consists of small decorative items worn for personal adornment, such as brooches, rings, necklaces, earrings, pendants, bracelets, and cuff-links.", "Jewelry", new Guid("46fdf615-ebd0-44d9-93b4-c664c47c7c00") },
                    { new Guid("f82e6f32-6e3c-4596-bd8b-19866a04eae2"), new DateTime(2024, 5, 21, 15, 23, 20, 405, DateTimeKind.Utc).AddTicks(7179), "Clothes are items worn on the body. They are typically made of fabrics or textiles but over time have included garments made from animal skin or other thin sheets of materials put together.", "Clothes", new Guid("58cfacb7-c221-4b64-89d4-f017d9fc29fa") }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "account_id", "created_date", "email", "gender", "is_deleted", "name", "phone", "version" },
                values: new object[,]
                {
                    { new Guid("4a5f48a8-f1ab-4f34-85f9-41e510c4e9a7"), null, new DateTime(2024, 5, 21, 15, 23, 20, 407, DateTimeKind.Utc).AddTicks(8293), "anna.johnson@gmail.com", (byte)2, false, "Anna Johnson", "0123456789", new Guid("1f742d0f-221f-4bc3-9871-a97f09050b96") },
                    { new Guid("6e97e8e8-739c-4b2c-9249-b22b48655559"), null, new DateTime(2024, 5, 21, 15, 23, 20, 407, DateTimeKind.Utc).AddTicks(8290), "maria.garcia@gmail.com", (byte)2, false, "Maria Garcia", "0123456789", new Guid("f86dbf90-30d8-4c36-8d0a-2cfd1f3b6b87") },
                    { new Guid("a95bea87-1260-4b4b-ad79-31ad1d9979d2"), new Guid("e5255692-c91f-43ba-937c-059895fd67a2"), new DateTime(2024, 5, 21, 15, 23, 20, 407, DateTimeKind.Utc).AddTicks(8493), "nguyenxuannhan.dev@gmail.com", (byte)1, false, "Fox Min Chan", "0123456789", new Guid("638c87b6-0bf0-4fb1-9505-580029f6679f") },
                    { new Guid("bc345864-d99e-4e4e-b109-c35fda184aff"), new Guid("7055bbfe-25c6-4b33-98cd-fc2b9fb4bb1a"), new DateTime(2024, 5, 21, 15, 23, 20, 407, DateTimeKind.Utc).AddTicks(8296), "nguyenxuannhan407@gmail.com", (byte)1, false, "Nhan Nguyen", "0123456789", new Guid("e72f8a8e-b1cc-489c-a8dc-479a5c81758c") },
                    { new Guid("c2882e2a-02d4-4f5d-be12-8d7ac20416d2"), null, new DateTime(2024, 5, 21, 15, 23, 20, 407, DateTimeKind.Utc).AddTicks(7528), "john.doe@gmail.com", (byte)1, false, "John Doe", "0123456789", new Guid("9e1da07a-2629-4cb0-aa81-a06cc1c6c9aa") },
                    { new Guid("d7884ac0-e821-4af9-8f72-3e0afed1bbf4"), null, new DateTime(2024, 5, 21, 15, 23, 20, 407, DateTimeKind.Utc).AddTicks(8244), "william.smith@gmail.com", (byte)1, false, "William Smith", "0123456789", new Guid("5bd9e3e5-7ba7-4b19-b582-792a82f6afd6") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("1b1637d7-9177-4ba9-bac5-cc297973098f"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("5bd7ae95-4ea7-4d61-a6fb-da2442383dd5"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("6d8df0fe-b0f9-4523-9f2b-d194dfca61e3"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("a6a2065d-df2a-42e7-a0f8-a26be4d4c7ad"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("f12dfb9b-1b6c-4302-8906-a0f262e6f280"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("f7285e91-9076-423e-98e9-30d7138ac72e"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("f82e6f32-6e3c-4596-bd8b-19866a04eae2"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("4a5f48a8-f1ab-4f34-85f9-41e510c4e9a7"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("6e97e8e8-739c-4b2c-9249-b22b48655559"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("a95bea87-1260-4b4b-ad79-31ad1d9979d2"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("bc345864-d99e-4e4e-b109-c35fda184aff"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("c2882e2a-02d4-4f5d-be12-8d7ac20416d2"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("d7884ac0-e821-4af9-8f72-3e0afed1bbf4"));

            migrationBuilder.DropColumn(
                name: "average_rating",
                table: "products");

            migrationBuilder.DropColumn(
                name: "total_reviews",
                table: "products");

            migrationBuilder.AlterColumn<Guid>(
                name: "version",
                table: "products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("79f84530-e1ae-4942-a178-c36a7fc53326"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("e36e46d5-b90e-4829-a5c6-8cd4e504ec63"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "products",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 277, DateTimeKind.Utc).AddTicks(1034),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 434, DateTimeKind.Utc).AddTicks(5522));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 277, DateTimeKind.Utc).AddTicks(193),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 434, DateTimeKind.Utc).AddTicks(5000));

            migrationBuilder.AlterColumn<Guid>(
                name: "version",
                table: "orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("06d257b6-d97c-4188-94e9-8147558582b0"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6b1007d2-1ef8-4cf6-9d0c-fb836ce6631c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "orders",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 255, DateTimeKind.Utc).AddTicks(6347),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 414, DateTimeKind.Utc).AddTicks(2969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 255, DateTimeKind.Utc).AddTicks(5679),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 414, DateTimeKind.Utc).AddTicks(2442));

            migrationBuilder.AlterColumn<Guid>(
                name: "version",
                table: "order_details",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("4a763110-16c7-4eb8-861e-405871622619"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("ff9b63a8-8ab1-46c5-87b9-1caadac55d54"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "order_details",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 274, DateTimeKind.Utc).AddTicks(1978),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 431, DateTimeKind.Utc).AddTicks(9719));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "order_details",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 274, DateTimeKind.Utc).AddTicks(1455),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 431, DateTimeKind.Utc).AddTicks(9255));

            migrationBuilder.AlterColumn<Guid>(
                name: "version",
                table: "feedbacks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("f72341f8-0bcf-4981-9673-4fe41091ee9c"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("e534c3f5-92fc-4991-b667-b5443f662c1c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "feedbacks",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 249, DateTimeKind.Utc).AddTicks(4752),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 408, DateTimeKind.Utc).AddTicks(7332));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "feedbacks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 249, DateTimeKind.Utc).AddTicks(4153),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 408, DateTimeKind.Utc).AddTicks(6794));

            migrationBuilder.AlterColumn<Guid>(
                name: "version",
                table: "customers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("3ff89c10-016d-44d0-84b3-28e18873f45e"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("46a006ad-98ee-4a7a-97e9-53f0d5896cfd"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "customers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 246, DateTimeKind.Utc).AddTicks(4029),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 406, DateTimeKind.Utc).AddTicks(2918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 246, DateTimeKind.Utc).AddTicks(3350),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 406, DateTimeKind.Utc).AddTicks(2411));

            migrationBuilder.AlterColumn<Guid>(
                name: "version",
                table: "categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("5ae072f4-2894-473b-8bd3-33e23a72415e"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("d8ad0b46-91b5-43c2-bf26-b22a4c5a1165"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_date",
                table: "categories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 236, DateTimeKind.Utc).AddTicks(4175),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 396, DateTimeKind.Utc).AddTicks(8707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 15, 17, 50, 20, 235, DateTimeKind.Utc).AddTicks(1469),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 21, 15, 23, 20, 395, DateTimeKind.Utc).AddTicks(6063));

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
        }
    }
}
