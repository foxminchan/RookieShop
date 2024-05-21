﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RookieShop.Persistence;

#nullable disable

namespace RookieShop.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240521152322_Add-AvgFeedback-TotalReviews")]
    partial class AddAvgFeedbackTotalReviews
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
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
                        .HasDefaultValue(new DateTime(2024, 5, 21, 15, 23, 20, 395, DateTimeKind.Utc).AddTicks(6063))
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
                        .HasDefaultValue(new DateTime(2024, 5, 21, 15, 23, 20, 396, DateTimeKind.Utc).AddTicks(8707))
                        .HasColumnName("update_date");

                    b.Property<Guid>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValue(new Guid("d8ad0b46-91b5-43c2-bf26-b22a4c5a1165"))
                        .HasColumnName("version");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.ToTable("categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f12dfb9b-1b6c-4302-8906-a0f262e6f280"),
                            CreatedDate = new DateTime(2024, 5, 21, 15, 23, 20, 405, DateTimeKind.Utc).AddTicks(6411),
                            Description = "A book is a medium for recording information in the form of writing or images, typically composed of many pages bound together and protected by a cover.",
                            Name = "Book",
                            Version = new Guid("cee31f65-eea0-45ef-bc0a-dace974996b3")
                        },
                        new
                        {
                            Id = new Guid("f82e6f32-6e3c-4596-bd8b-19866a04eae2"),
                            CreatedDate = new DateTime(2024, 5, 21, 15, 23, 20, 405, DateTimeKind.Utc).AddTicks(7179),
                            Description = "Clothes are items worn on the body. They are typically made of fabrics or textiles but over time have included garments made from animal skin or other thin sheets of materials put together.",
                            Name = "Clothes",
                            Version = new Guid("58cfacb7-c221-4b64-89d4-f017d9fc29fa")
                        },
                        new
                        {
                            Id = new Guid("1b1637d7-9177-4ba9-bac5-cc297973098f"),
                            CreatedDate = new DateTime(2024, 5, 21, 15, 23, 20, 405, DateTimeKind.Utc).AddTicks(7229),
                            Description = "Electronics comprises the physics, engineering, technology and applications that deal with the emission, flow and control of electrons in vacuum and matter.",
                            Name = "Electronics",
                            Version = new Guid("09083972-1d9b-4692-a65b-0cac146d920c")
                        },
                        new
                        {
                            Id = new Guid("a6a2065d-df2a-42e7-a0f8-a26be4d4c7ad"),
                            CreatedDate = new DateTime(2024, 5, 21, 15, 23, 20, 405, DateTimeKind.Utc).AddTicks(7232),
                            Description = "Furniture refers to movable objects intended to support various human activities such as seating, eating, and sleeping.",
                            Name = "Furniture",
                            Version = new Guid("dddd0a97-de43-442e-b288-5177c823973e")
                        },
                        new
                        {
                            Id = new Guid("f7285e91-9076-423e-98e9-30d7138ac72e"),
                            CreatedDate = new DateTime(2024, 5, 21, 15, 23, 20, 405, DateTimeKind.Utc).AddTicks(7238),
                            Description = "Jewellery consists of small decorative items worn for personal adornment, such as brooches, rings, necklaces, earrings, pendants, bracelets, and cuff-links.",
                            Name = "Jewelry",
                            Version = new Guid("46fdf615-ebd0-44d9-93b4-c664c47c7c00")
                        },
                        new
                        {
                            Id = new Guid("5bd7ae95-4ea7-4d61-a6fb-da2442383dd5"),
                            CreatedDate = new DateTime(2024, 5, 21, 15, 23, 20, 405, DateTimeKind.Utc).AddTicks(7243),
                            Description = "A shoe is an item of footwear intended to protect and comfort the human foot. Shoes",
                            Name = "Shoes",
                            Version = new Guid("48990606-4993-49c7-8151-cd7afd8487ca")
                        },
                        new
                        {
                            Id = new Guid("6d8df0fe-b0f9-4523-9f2b-d194dfca61e3"),
                            CreatedDate = new DateTime(2024, 5, 21, 15, 23, 20, 405, DateTimeKind.Utc).AddTicks(7245),
                            Description = "Sport includes all forms of competitive physical activity or games which, through casual or organized participation, at least in part aim to use, maintain or improve physical ability and skills while providing enjoyment to participants, and in some cases, entertainment for spectators.",
                            Name = "Sport",
                            Version = new Guid("2abb2a0a-f27b-4a63-9f0f-c90a30a1dc2c")
                        });
                });

            modelBuilder.Entity("RookieShop.Domain.Entities.CustomerAggregator.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("account_id");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 21, 15, 23, 20, 406, DateTimeKind.Utc).AddTicks(2411))
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
                        .HasDefaultValue(new DateTime(2024, 5, 21, 15, 23, 20, 406, DateTimeKind.Utc).AddTicks(2918))
                        .HasColumnName("update_date");

                    b.Property<Guid>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValue(new Guid("46a006ad-98ee-4a7a-97e9-53f0d5896cfd"))
                        .HasColumnName("version");

                    b.HasKey("Id")
                        .HasName("pk_customers");

                    b.ToTable("customers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c2882e2a-02d4-4f5d-be12-8d7ac20416d2"),
                            CreatedDate = new DateTime(2024, 5, 21, 15, 23, 20, 407, DateTimeKind.Utc).AddTicks(7528),
                            Email = "john.doe@gmail.com",
                            Gender = (byte)1,
                            IsDeleted = false,
                            Name = "John Doe",
                            Phone = "0123456789",
                            Version = new Guid("9e1da07a-2629-4cb0-aa81-a06cc1c6c9aa")
                        },
                        new
                        {
                            Id = new Guid("d7884ac0-e821-4af9-8f72-3e0afed1bbf4"),
                            CreatedDate = new DateTime(2024, 5, 21, 15, 23, 20, 407, DateTimeKind.Utc).AddTicks(8244),
                            Email = "william.smith@gmail.com",
                            Gender = (byte)1,
                            IsDeleted = false,
                            Name = "William Smith",
                            Phone = "0123456789",
                            Version = new Guid("5bd9e3e5-7ba7-4b19-b582-792a82f6afd6")
                        },
                        new
                        {
                            Id = new Guid("6e97e8e8-739c-4b2c-9249-b22b48655559"),
                            CreatedDate = new DateTime(2024, 5, 21, 15, 23, 20, 407, DateTimeKind.Utc).AddTicks(8290),
                            Email = "maria.garcia@gmail.com",
                            Gender = (byte)2,
                            IsDeleted = false,
                            Name = "Maria Garcia",
                            Phone = "0123456789",
                            Version = new Guid("f86dbf90-30d8-4c36-8d0a-2cfd1f3b6b87")
                        },
                        new
                        {
                            Id = new Guid("4a5f48a8-f1ab-4f34-85f9-41e510c4e9a7"),
                            CreatedDate = new DateTime(2024, 5, 21, 15, 23, 20, 407, DateTimeKind.Utc).AddTicks(8293),
                            Email = "anna.johnson@gmail.com",
                            Gender = (byte)2,
                            IsDeleted = false,
                            Name = "Anna Johnson",
                            Phone = "0123456789",
                            Version = new Guid("1f742d0f-221f-4bc3-9871-a97f09050b96")
                        },
                        new
                        {
                            Id = new Guid("bc345864-d99e-4e4e-b109-c35fda184aff"),
                            AccountId = new Guid("7055bbfe-25c6-4b33-98cd-fc2b9fb4bb1a"),
                            CreatedDate = new DateTime(2024, 5, 21, 15, 23, 20, 407, DateTimeKind.Utc).AddTicks(8296),
                            Email = "nguyenxuannhan407@gmail.com",
                            Gender = (byte)1,
                            IsDeleted = false,
                            Name = "Nhan Nguyen",
                            Phone = "0123456789",
                            Version = new Guid("e72f8a8e-b1cc-489c-a8dc-479a5c81758c")
                        },
                        new
                        {
                            Id = new Guid("a95bea87-1260-4b4b-ad79-31ad1d9979d2"),
                            AccountId = new Guid("e5255692-c91f-43ba-937c-059895fd67a2"),
                            CreatedDate = new DateTime(2024, 5, 21, 15, 23, 20, 407, DateTimeKind.Utc).AddTicks(8493),
                            Email = "nguyenxuannhan.dev@gmail.com",
                            Gender = (byte)1,
                            IsDeleted = false,
                            Name = "Fox Min Chan",
                            Phone = "0123456789",
                            Version = new Guid("638c87b6-0bf0-4fb1-9505-580029f6679f")
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
                        .HasDefaultValue(new DateTime(2024, 5, 21, 15, 23, 20, 408, DateTimeKind.Utc).AddTicks(6794))
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
                        .HasDefaultValue(new DateTime(2024, 5, 21, 15, 23, 20, 408, DateTimeKind.Utc).AddTicks(7332))
                        .HasColumnName("update_date");

                    b.Property<Guid>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValue(new Guid("e534c3f5-92fc-4991-b667-b5443f662c1c"))
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
                        .HasDefaultValue(new DateTime(2024, 5, 21, 15, 23, 20, 414, DateTimeKind.Utc).AddTicks(2442))
                        .HasColumnName("created_date");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<byte>("OrderStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("order_status");

                    b.Property<byte>("PaymentMethod")
                        .HasColumnType("smallint")
                        .HasColumnName("payment_method");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 21, 15, 23, 20, 414, DateTimeKind.Utc).AddTicks(2969))
                        .HasColumnName("update_date");

                    b.Property<Guid>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValue(new Guid("6b1007d2-1ef8-4cf6-9d0c-fb836ce6631c"))
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
                        .HasDefaultValue(new DateTime(2024, 5, 21, 15, 23, 20, 431, DateTimeKind.Utc).AddTicks(9255))
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
                        .HasDefaultValue(new DateTime(2024, 5, 21, 15, 23, 20, 431, DateTimeKind.Utc).AddTicks(9719))
                        .HasColumnName("update_date");

                    b.Property<Guid>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValue(new Guid("ff9b63a8-8ab1-46c5-87b9-1caadac55d54"))
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

                    b.Property<double>("AverageRating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0)
                        .HasColumnName("average_rating");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 21, 15, 23, 20, 434, DateTimeKind.Utc).AddTicks(5000))
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

                    b.Property<int>("TotalReviews")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("total_reviews");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 5, 21, 15, 23, 20, 434, DateTimeKind.Utc).AddTicks(5522))
                        .HasColumnName("update_date");

                    b.Property<Guid>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValue(new Guid("e36e46d5-b90e-4829-a5c6-8cd4e504ec63"))
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
