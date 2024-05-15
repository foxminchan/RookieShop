﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SeedWork;

#pragma warning disable 219, 612, 618
#nullable disable

namespace RookieShop.Persistence.CompiledModels
{
    internal partial class FeedbackEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "RookieShop.Domain.Entities.FeedbackAggregator.Feedback",
                typeof(Feedback),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(FeedbackId),
                propertyInfo: typeof(Feedback).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Feedback).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);
            id.TypeMapping = GuidTypeMapping.Default.Clone(
                comparer: new ValueComparer<FeedbackId>(
                    (FeedbackId v1, FeedbackId v2) => v1.Equals(v2),
                    (FeedbackId v) => v.GetHashCode(),
                    (FeedbackId v) => v),
                keyComparer: new ValueComparer<FeedbackId>(
                    (FeedbackId v1, FeedbackId v2) => v1.Equals(v2),
                    (FeedbackId v) => v.GetHashCode(),
                    (FeedbackId v) => v),
                providerValueComparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "uuid"),
                converter: new ValueConverter<FeedbackId, Guid>(
                    (FeedbackId id) => id.Value,
                    (Guid value) => new FeedbackId(value)),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<FeedbackId, Guid>(
                    JsonGuidReaderWriter.Instance,
                    new ValueConverter<FeedbackId, Guid>(
                        (FeedbackId id) => id.Value,
                        (Guid value) => new FeedbackId(value))));
            id.SetSentinelFromProviderValue(new Guid("00000000-0000-0000-0000-000000000000"));
            id.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            id.AddAnnotation("Relational:ColumnName", "id");
            id.AddAnnotation("Relational:DefaultValueSql", "uuid_generate_v4()");

            var content = runtimeEntityType.AddProperty(
                "Content",
                typeof(string),
                propertyInfo: typeof(Feedback).GetProperty("Content", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Feedback).GetField("<Content>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 1000);
            content.TypeMapping = NpgsqlStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "character varying(1000)",
                    size: 1000));
            content.TypeMapping = ((NpgsqlStringTypeMapping)content.TypeMapping).Clone(npgsqlDbType: NpgsqlTypes.NpgsqlDbType.Varchar);
        content.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        content.AddAnnotation("Relational:ColumnName", "content");

        var createdDate = runtimeEntityType.AddProperty(
            "CreatedDate",
            typeof(DateTime),
            propertyInfo: typeof(EntityBase).GetProperty("CreatedDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(EntityBase).GetField("<CreatedDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            valueGenerated: ValueGenerated.OnAdd,
            sentinel: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        createdDate.TypeMapping = NpgsqlTimestampTzTypeMapping.Default.Clone(
            comparer: new ValueComparer<DateTime>(
                (DateTime v1, DateTime v2) => v1.Equals(v2),
                (DateTime v) => v.GetHashCode(),
                (DateTime v) => v),
            keyComparer: new ValueComparer<DateTime>(
                (DateTime v1, DateTime v2) => v1.Equals(v2),
                (DateTime v) => v.GetHashCode(),
                (DateTime v) => v),
            providerValueComparer: new ValueComparer<DateTime>(
                (DateTime v1, DateTime v2) => v1.Equals(v2),
                (DateTime v) => v.GetHashCode(),
                (DateTime v) => v));
        createdDate.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        createdDate.AddAnnotation("Relational:ColumnName", "created_date");
        createdDate.AddAnnotation("Relational:DefaultValue", new DateTime(2024, 5, 15, 7, 14, 30, 163, DateTimeKind.Utc).AddTicks(9218));

        var customerId = runtimeEntityType.AddProperty(
            "CustomerId",
            typeof(CustomerId?),
            propertyInfo: typeof(Feedback).GetProperty("CustomerId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(Feedback).GetField("<CustomerId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            nullable: true);
        customerId.TypeMapping = GuidTypeMapping.Default.Clone(
            comparer: new ValueComparer<CustomerId?>(
                (Nullable<CustomerId> v1, Nullable<CustomerId> v2) => v1.HasValue && v2.HasValue && ((CustomerId)v1).Equals((CustomerId)v2) || !v1.HasValue && !v2.HasValue,
                (Nullable<CustomerId> v) => v.HasValue ? ((CustomerId)v).GetHashCode() : 0,
                (Nullable<CustomerId> v) => v.HasValue ? (Nullable<CustomerId>)(CustomerId)v : default(Nullable<CustomerId>)),
            keyComparer: new ValueComparer<CustomerId?>(
                (Nullable<CustomerId> v1, Nullable<CustomerId> v2) => v1.HasValue && v2.HasValue && ((CustomerId)v1).Equals((CustomerId)v2) || !v1.HasValue && !v2.HasValue,
                (Nullable<CustomerId> v) => v.HasValue ? ((CustomerId)v).GetHashCode() : 0,
                (Nullable<CustomerId> v) => v.HasValue ? (Nullable<CustomerId>)(CustomerId)v : default(Nullable<CustomerId>)),
            providerValueComparer: new ValueComparer<Guid>(
                (Guid v1, Guid v2) => v1 == v2,
                (Guid v) => v.GetHashCode(),
                (Guid v) => v),
            mappingInfo: new RelationalTypeMappingInfo(
                storeTypeName: "uuid"),
            converter: new ValueConverter<CustomerId, Guid>(
                (CustomerId id) => id.Value,
                (Guid value) => new CustomerId(value)),
            jsonValueReaderWriter: new JsonConvertedValueReaderWriter<CustomerId, Guid>(
                JsonGuidReaderWriter.Instance,
                new ValueConverter<CustomerId, Guid>(
                    (CustomerId id) => id.Value,
                    (Guid value) => new CustomerId(value))));
        customerId.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        customerId.AddAnnotation("Relational:ColumnName", "customer_id");

        var productId = runtimeEntityType.AddProperty(
            "ProductId",
            typeof(ProductId),
            propertyInfo: typeof(Feedback).GetProperty("ProductId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(Feedback).GetField("<ProductId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
        productId.TypeMapping = GuidTypeMapping.Default.Clone(
            comparer: new ValueComparer<ProductId>(
                (ProductId v1, ProductId v2) => v1.Equals(v2),
                (ProductId v) => v.GetHashCode(),
                (ProductId v) => v),
            keyComparer: new ValueComparer<ProductId>(
                (ProductId v1, ProductId v2) => v1.Equals(v2),
                (ProductId v) => v.GetHashCode(),
                (ProductId v) => v),
            providerValueComparer: new ValueComparer<Guid>(
                (Guid v1, Guid v2) => v1 == v2,
                (Guid v) => v.GetHashCode(),
                (Guid v) => v),
            mappingInfo: new RelationalTypeMappingInfo(
                storeTypeName: "uuid"),
            converter: new ValueConverter<ProductId, Guid>(
                (ProductId id) => id.Value,
                (Guid value) => new ProductId(value)),
            jsonValueReaderWriter: new JsonConvertedValueReaderWriter<ProductId, Guid>(
                JsonGuidReaderWriter.Instance,
                new ValueConverter<ProductId, Guid>(
                    (ProductId id) => id.Value,
                    (Guid value) => new ProductId(value))));
        productId.SetSentinelFromProviderValue(new Guid("00000000-0000-0000-0000-000000000000"));
        productId.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        productId.AddAnnotation("Relational:ColumnName", "product_id");

        var rating = runtimeEntityType.AddProperty(
            "Rating",
            typeof(int),
            propertyInfo: typeof(Feedback).GetProperty("Rating", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(Feedback).GetField("<Rating>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            sentinel: 0);
        rating.TypeMapping = IntTypeMapping.Default.Clone(
            comparer: new ValueComparer<int>(
                (int v1, int v2) => v1 == v2,
                (int v) => v,
                (int v) => v),
            keyComparer: new ValueComparer<int>(
                (int v1, int v2) => v1 == v2,
                (int v) => v,
                (int v) => v),
            providerValueComparer: new ValueComparer<int>(
                (int v1, int v2) => v1 == v2,
                (int v) => v,
                (int v) => v),
            mappingInfo: new RelationalTypeMappingInfo(
                storeTypeName: "integer"));
        rating.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        rating.AddAnnotation("Relational:ColumnName", "rating");

        var updateDate = runtimeEntityType.AddProperty(
            "UpdateDate",
            typeof(DateTime?),
            propertyInfo: typeof(EntityBase).GetProperty("UpdateDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(EntityBase).GetField("<UpdateDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            nullable: true,
            valueGenerated: ValueGenerated.OnAdd);
        updateDate.TypeMapping = NpgsqlTimestampTzTypeMapping.Default.Clone(
            comparer: new ValueComparer<DateTime?>(
                (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)),
            keyComparer: new ValueComparer<DateTime?>(
                (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)),
            providerValueComparer: new ValueComparer<DateTime?>(
                (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)));
        updateDate.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        updateDate.AddAnnotation("Relational:ColumnName", "update_date");
        updateDate.AddAnnotation("Relational:DefaultValue", new DateTime(2024, 5, 15, 7, 14, 30, 163, DateTimeKind.Utc).AddTicks(9486));

        var version = runtimeEntityType.AddProperty(
            "Version",
            typeof(Guid),
            propertyInfo: typeof(EntityBase).GetProperty("Version", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(EntityBase).GetField("<Version>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            concurrencyToken: true,
            valueGenerated: ValueGenerated.OnAdd,
            sentinel: new Guid("00000000-0000-0000-0000-000000000000"));
        version.TypeMapping = GuidTypeMapping.Default.Clone(
            comparer: new ValueComparer<Guid>(
                (Guid v1, Guid v2) => v1 == v2,
                (Guid v) => v.GetHashCode(),
                (Guid v) => v),
            keyComparer: new ValueComparer<Guid>(
                (Guid v1, Guid v2) => v1 == v2,
                (Guid v) => v.GetHashCode(),
                (Guid v) => v),
            providerValueComparer: new ValueComparer<Guid>(
                (Guid v1, Guid v2) => v1 == v2,
                (Guid v) => v.GetHashCode(),
                (Guid v) => v),
            mappingInfo: new RelationalTypeMappingInfo(
                storeTypeName: "uuid"));
        version.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        version.AddAnnotation("Relational:ColumnName", "version");
        version.AddAnnotation("Relational:DefaultValue", new Guid("cefbe22b-5557-4894-8b88-d0e49d895783"));

        var key = runtimeEntityType.AddKey(
            new[] { id });
        runtimeEntityType.SetPrimaryKey(key);
        key.AddAnnotation("Relational:Name", "pk_feedbacks");

        var index = runtimeEntityType.AddIndex(
            new[] { customerId });
        index.AddAnnotation("Relational:Name", "ix_feedbacks_customer_id");

        var index0 = runtimeEntityType.AddIndex(
            new[] { productId });
        index0.AddAnnotation("Relational:Name", "ix_feedbacks_product_id");

        return runtimeEntityType;
    }

    public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
    {
        var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("CustomerId") },
            principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
            principalEntityType,
            deleteBehavior: DeleteBehavior.Restrict);

        var customer = declaringEntityType.AddNavigation("Customer",
            runtimeForeignKey,
            onDependent: true,
            typeof(Customer),
            propertyInfo: typeof(Feedback).GetProperty("Customer", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(Feedback).GetField("<Customer>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            eagerLoaded: true);

        var feedbacks = principalEntityType.AddNavigation("Feedbacks",
            runtimeForeignKey,
            onDependent: false,
            typeof(ICollection<Feedback>),
            propertyInfo: typeof(Customer).GetProperty("Feedbacks", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(Customer).GetField("<Feedbacks>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

        runtimeForeignKey.AddAnnotation("Relational:Name", "fk_feedbacks_customers_customer_id");
        return runtimeForeignKey;
    }

    public static RuntimeForeignKey CreateForeignKey2(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
    {
        var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("ProductId") },
            principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
            principalEntityType,
            deleteBehavior: DeleteBehavior.Restrict,
            required: true);

        var product = declaringEntityType.AddNavigation("Product",
            runtimeForeignKey,
            onDependent: true,
            typeof(Product),
            propertyInfo: typeof(Feedback).GetProperty("Product", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(Feedback).GetField("<Product>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

        var feedbacks = principalEntityType.AddNavigation("Feedbacks",
            runtimeForeignKey,
            onDependent: false,
            typeof(IReadOnlyCollection<Feedback>),
            propertyInfo: typeof(Product).GetProperty("Feedbacks", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(Product).GetField("<Feedbacks>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            eagerLoaded: true);

        runtimeForeignKey.AddAnnotation("Relational:Name", "fk_feedbacks_products_product_id");
        return runtimeForeignKey;
    }

    public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
    {
        runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
        runtimeEntityType.AddAnnotation("Relational:Schema", null);
        runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
        runtimeEntityType.AddAnnotation("Relational:TableName", "feedbacks");
        runtimeEntityType.AddAnnotation("Relational:ViewName", null);
        runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

        Customize(runtimeEntityType);
    }

    static partial void Customize(RuntimeEntityType runtimeEntityType);
}
}
