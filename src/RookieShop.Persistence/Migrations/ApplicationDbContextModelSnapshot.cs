﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RookieShop.Persistence;

#nullable disable

namespace RookieShop.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RookieShop.Domain.Entities.CategoryAggregator.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 15, 7, 16, 24, 694, DateTimeKind.Utc).AddTicks(9469))
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 15, 7, 16, 24, 696, DateTimeKind.Utc).AddTicks(1999))
                        .HasColumnName("update_date");

                    b.Property<Guid>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValue(new Guid("e0de071f-338e-4fd3-865f-c825b0526481"))
                        .HasColumnName("version");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.ToTable("categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2ca40d95-5654-4fe2-afb2-9164a232e0cd"),
                            CreatedDate = new DateTime(2024, 5, 15, 7, 16, 24, 704, DateTimeKind.Utc).AddTicks(9912),
                            Description = "A book is a medium for recording information in the form of writing or images, typically composed of many pages bound together and protected by a cover.",
                            Name = "Book",
                            Version = new Guid("57f105a6-d564-4f21-ab99-88b6143a0dea")
                        },
                        new
                        {
                            Id = new Guid("b24c1344-0105-4153-9357-cfd978231347"),
                            CreatedDate = new DateTime(2024, 5, 15, 7, 16, 24, 705, DateTimeKind.Utc).AddTicks(1037),
                            Description = "Clothes are items worn on the body. They are typically made of fabrics or textiles but over time have included garments made from animal skin or other thin sheets of materials put together.",
                            Name = "Clothes",
                            Version = new Guid("ad26a05e-1ba8-4e57-8581-9dceefc69cc3")
                        },
                        new
                        {
                            Id = new Guid("88e21030-f59d-4a7c-aaad-1f3fd144dc7c"),
                            CreatedDate = new DateTime(2024, 5, 15, 7, 16, 24, 705, DateTimeKind.Utc).AddTicks(1102),
                            Description = "Electronics comprises the physics, engineering, technology and applications that deal with the emission, flow and control of electrons in vacuum and matter.",
                            Name = "Electronics",
                            Version = new Guid("1b32bdd8-fcb0-411a-90fc-0760b6b46f52")
                        },
                        new
                        {
                            Id = new Guid("e909ef55-2792-4ec1-b8b7-9cd5b7718fad"),
                            CreatedDate = new DateTime(2024, 5, 15, 7, 16, 24, 705, DateTimeKind.Utc).AddTicks(1105),
                            Description = "Furniture refers to movable objects intended to support various human activities such as seating, eating, and sleeping.",
                            Name = "Furniture",
                            Version = new Guid("fd804247-23f1-4d97-b3ff-73389aa1eef2")
                        },
                        new
                        {
                            Id = new Guid("77756616-81de-4722-847a-1c9a0419177e"),
                            CreatedDate = new DateTime(2024, 5, 15, 7, 16, 24, 705, DateTimeKind.Utc).AddTicks(1107),
                            Description = "Jewellery consists of small decorative items worn for personal adornment, such as brooches, rings, necklaces, earrings, pendants, bracelets, and cufflinks.",
                            Name = "Jewelry",
                            Version = new Guid("56aed567-fb14-4fbb-86e9-3ca00e4254fc")
                        });
                });

            modelBuilder.Entity("RookieShop.Domain.Entities.CustomerAggregator.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("AccountId")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("account_id");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 15, 7, 16, 24, 705, DateTimeKind.Utc).AddTicks(6967))
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<byte>("Gender")
                        .HasColumnType("smallint")
                        .HasColumnName("gender");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("phone");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 15, 7, 16, 24, 705, DateTimeKind.Utc).AddTicks(7512))
                        .HasColumnName("update_date");

                    b.Property<Guid>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValue(new Guid("de0d5421-c7c0-4e19-b173-fad59187821e"))
                        .HasColumnName("version");

                    b.HasKey("Id")
                        .HasName("pk_customers");

                    b.ToTable("customers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8a572fee-d4b6-401e-8855-5326e587eb47"),
                            CreatedDate = new DateTime(2024, 5, 15, 7, 16, 24, 707, DateTimeKind.Utc).AddTicks(8918),
                            Email = "john.doe@gmail.com",
                            Gender = (byte)1,
                            IsDeleted = false,
                            Name = "John Doe",
                            Phone = "0123456789",
                            Version = new Guid("abe60d87-b92a-42f7-9d30-92c1e68712bc")
                        },
                        new
                        {
                            Id = new Guid("613d2282-40c6-49ca-a440-9ec8273dd780"),
                            CreatedDate = new DateTime(2024, 5, 15, 7, 16, 24, 707, DateTimeKind.Utc).AddTicks(9642),
                            Email = "william.smith@gmail.com",
                            Gender = (byte)1,
                            IsDeleted = false,
                            Name = "William Smith",
                            Phone = "0123456789",
                            Version = new Guid("67f63d8d-2378-4d13-a6d0-6b25d3648ccb")
                        },
                        new
                        {
                            Id = new Guid("14879784-e536-4da9-a216-3cc4391a2400"),
                            CreatedDate = new DateTime(2024, 5, 15, 7, 16, 24, 707, DateTimeKind.Utc).AddTicks(9711),
                            Email = "maria.garcia@gmail.com",
                            Gender = (byte)2,
                            IsDeleted = false,
                            Name = "Maria Garcia",
                            Phone = "0123456789",
                            Version = new Guid("81775316-dcf1-4e60-918c-3b73cc7d43b3")
                        },
                        new
                        {
                            Id = new Guid("fc4d736b-1cb8-4b95-bb3c-d41850af29b4"),
                            CreatedDate = new DateTime(2024, 5, 15, 7, 16, 24, 707, DateTimeKind.Utc).AddTicks(9715),
                            Email = "anna.johnson@gmail.com",
                            Gender = (byte)2,
                            IsDeleted = false,
                            Name = "Anna Johnson",
                            Phone = "0123456789",
                            Version = new Guid("871def9c-f944-4c2c-8434-421b1a074c13")
                        });
                });

            modelBuilder.Entity("RookieShop.Domain.Entities.FeedbackAggregator.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 15, 7, 16, 24, 709, DateTimeKind.Utc).AddTicks(409))
                        .HasColumnName("created_date");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 15, 7, 16, 24, 709, DateTimeKind.Utc).AddTicks(967))
                        .HasColumnName("update_date");

                    b.Property<Guid>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValue(new Guid("0dc72ce5-53ac-4893-9e14-258816e3260b"))
                        .HasColumnName("version");

                    b.HasKey("Id")
                        .HasName("pk_feedbacks");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("ix_feedbacks_customer_id");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_feedbacks_product_id");

                    b.ToTable("feedbacks", (string)null);
                });

            modelBuilder.Entity("RookieShop.Domain.Entities.OrderAggregator.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 15, 7, 16, 24, 714, DateTimeKind.Utc).AddTicks(4388))
                        .HasColumnName("created_date");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<byte>("PaymentMethod")
                        .HasColumnType("smallint")
                        .HasColumnName("payment_method");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 15, 7, 16, 24, 714, DateTimeKind.Utc).AddTicks(4876))
                        .HasColumnName("update_date");

                    b.Property<Guid>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValue(new Guid("ce33cab6-52c4-4e6f-b9c9-dd0a66b556f1"))
                        .HasColumnName("version");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("ix_orders_customer_id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("RookieShop.Domain.Entities.OrderAggregator.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 15, 7, 16, 24, 732, DateTimeKind.Utc).AddTicks(1880))
                        .HasColumnName("created_date");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 15, 7, 16, 24, 732, DateTimeKind.Utc).AddTicks(2399))
                        .HasColumnName("update_date");

                    b.Property<Guid>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValue(new Guid("0df92617-82dc-4b72-85ec-6ed0cd10f64a"))
                        .HasColumnName("version");

                    b.HasKey("OrderId", "ProductId")
                        .HasName("pk_order_details");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_order_details_product_id");

                    b.ToTable("order_details", (string)null);
                });

            modelBuilder.Entity("RookieShop.Domain.Entities.ProductAggregator.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 15, 7, 16, 24, 734, DateTimeKind.Utc).AddTicks(9739))
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("description");

                    b.Property<string>("ImageName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("image_name");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("quantity");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 15, 7, 16, 24, 735, DateTimeKind.Utc).AddTicks(502))
                        .HasColumnName("update_date");

                    b.Property<Guid>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValue(new Guid("a346cff4-4623-4a77-b36b-65fee11bc169"))
                        .HasColumnName("version");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_products_category_id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("RookieShop.Domain.Entities.FeedbackAggregator.Feedback", b =>
                {
                    b.HasOne("RookieShop.Domain.Entities.CustomerAggregator.Customer", "Customer")
                        .WithMany("Feedbacks")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_feedbacks_customers_customer_id");

                    b.HasOne("RookieShop.Domain.Entities.ProductAggregator.Product", "Product")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_feedbacks_products_product_id");

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RookieShop.Domain.Entities.OrderAggregator.Order", b =>
                {
                    b.HasOne("RookieShop.Domain.Entities.CustomerAggregator.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_orders_customers_customer_id");

                    b.OwnsOne("RookieShop.Domain.Entities.OrderAggregator.ValueObjects.Card", "Card", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("BrandName")
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("card_brand_name");

                            b1.Property<string>("ChargeId")
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("card_charge_id");

                            b1.Property<string>("Last4Digits")
                                .HasMaxLength(4)
                                .HasColumnType("character(4)")
                                .HasColumnName("card_last4digits")
                                .IsFixedLength();

                            b1.HasKey("OrderId");

                            b1.ToTable("orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId")
                                .HasConstraintName("fk_orders_orders_id");
                        });

                    b.OwnsOne("RookieShop.Domain.Entities.OrderAggregator.ValueObjects.ShippingAddress", "ShippingAddress", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("City")
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("shipping_address_city");

                            b1.Property<string>("Province")
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("shipping_address_province");

                            b1.Property<string>("Street")
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("shipping_address_street");

                            b1.HasKey("OrderId");

                            b1.ToTable("orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId")
                                .HasConstraintName("fk_orders_orders_id");
                        });

                    b.Navigation("Card");

                    b.Navigation("Customer");

                    b.Navigation("ShippingAddress");
                });

            modelBuilder.Entity("RookieShop.Domain.Entities.OrderAggregator.OrderDetail", b =>
                {
                    b.HasOne("RookieShop.Domain.Entities.OrderAggregator.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_details_orders_order_id");

                    b.HasOne("RookieShop.Domain.Entities.ProductAggregator.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_order_details_products_product_id");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RookieShop.Domain.Entities.ProductAggregator.Product", b =>
                {
                    b.HasOne("RookieShop.Domain.Entities.CategoryAggregator.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_products_categories_category_id");

                    b.OwnsOne("RookieShop.Domain.Entities.ProductAggregator.ValueObjects.ProductPrice", "Price", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Price")
                                .HasColumnType("numeric");

                            b1.Property<decimal>("PriceSale")
                                .HasColumnType("numeric");

                            b1.HasKey("ProductId");

                            b1.ToTable("products");

                            b1.ToJson("price");

                            b1.WithOwner()
                                .HasForeignKey("ProductId")
                                .HasConstraintName("fk_products_products_id");
                        });

                    b.Navigation("Category");

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("RookieShop.Domain.Entities.CategoryAggregator.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("RookieShop.Domain.Entities.CustomerAggregator.Customer", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RookieShop.Domain.Entities.OrderAggregator.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("RookieShop.Domain.Entities.ProductAggregator.Product", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
