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
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Enums;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SeedWork;

#pragma warning disable 219, 612, 618
#nullable disable

namespace RookieShop.Persistence.CompiledModels
{
    internal partial class ProductEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "RookieShop.Domain.Entities.ProductAggregator.Product",
                typeof(Product),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(ProductId),
                propertyInfo: typeof(Product).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);
            id.TypeMapping = GuidTypeMapping.Default.Clone(
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
            id.SetSentinelFromProviderValue(new Guid("00000000-0000-0000-0000-000000000000"));
            id.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            id.AddAnnotation("Relational:ColumnName", "id");
            id.AddAnnotation("Relational:DefaultValueSql", "uuid_generate_v4()");

            var categoryId = runtimeEntityType.AddProperty(
                "CategoryId",
                typeof(CategoryId?),
                propertyInfo: typeof(Product).GetProperty("CategoryId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<CategoryId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            categoryId.TypeMapping = GuidTypeMapping.Default.Clone(
                comparer: new ValueComparer<CategoryId?>(
                    (Nullable<CategoryId> v1, Nullable<CategoryId> v2) => v1.HasValue && v2.HasValue && ((CategoryId)v1).Equals((CategoryId)v2) || !v1.HasValue && !v2.HasValue,
                    (Nullable<CategoryId> v) => v.HasValue ? ((CategoryId)v).GetHashCode() : 0,
                    (Nullable<CategoryId> v) => v.HasValue ? (Nullable<CategoryId>)(CategoryId)v : default(Nullable<CategoryId>)),
                keyComparer: new ValueComparer<CategoryId?>(
                    (Nullable<CategoryId> v1, Nullable<CategoryId> v2) => v1.HasValue && v2.HasValue && ((CategoryId)v1).Equals((CategoryId)v2) || !v1.HasValue && !v2.HasValue,
                    (Nullable<CategoryId> v) => v.HasValue ? ((CategoryId)v).GetHashCode() : 0,
                    (Nullable<CategoryId> v) => v.HasValue ? (Nullable<CategoryId>)(CategoryId)v : default(Nullable<CategoryId>)),
                providerValueComparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "uuid"),
                converter: new ValueConverter<CategoryId, Guid>(
                    (CategoryId id) => id.Value,
                    (Guid value) => new CategoryId(value)),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<CategoryId, Guid>(
                    JsonGuidReaderWriter.Instance,
                    new ValueConverter<CategoryId, Guid>(
                        (CategoryId id) => id.Value,
                        (Guid value) => new CategoryId(value))));
            categoryId.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            categoryId.AddAnnotation("Relational:ColumnName", "category_id");

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
            createdDate.AddAnnotation("Relational:DefaultValue", new DateTime(2024, 5, 15, 17, 49, 26, 120, DateTimeKind.Utc).AddTicks(9526));

            var description = runtimeEntityType.AddProperty(
                "Description",
                typeof(string),
                propertyInfo: typeof(Product).GetProperty("Description", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<Description>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 1000);
            description.TypeMapping = NpgsqlStringTypeMapping.Default.Clone(
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
            description.TypeMapping = ((NpgsqlStringTypeMapping)description.TypeMapping).Clone(npgsqlDbType: NpgsqlTypes.NpgsqlDbType.Varchar);
        description.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        description.AddAnnotation("Relational:ColumnName", "description");

        var imageName = runtimeEntityType.AddProperty(
            "ImageName",
            typeof(string),
            propertyInfo: typeof(Product).GetProperty("ImageName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(Product).GetField("<ImageName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            nullable: true,
            maxLength: 50);
        imageName.TypeMapping = NpgsqlStringTypeMapping.Default.Clone(
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
                storeTypeName: "character varying(50)",
                size: 50));
        imageName.TypeMapping = ((NpgsqlStringTypeMapping)imageName.TypeMapping).Clone(npgsqlDbType: NpgsqlTypes.NpgsqlDbType.Varchar);
    imageName.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
    imageName.AddAnnotation("Relational:ColumnName", "image_name");

    var isDeleted = runtimeEntityType.AddProperty(
        "IsDeleted",
        typeof(bool),
        propertyInfo: typeof(Product).GetProperty("IsDeleted", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        fieldInfo: typeof(Product).GetField("<IsDeleted>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        sentinel: false);
    isDeleted.TypeMapping = NpgsqlBoolTypeMapping.Default.Clone(
        comparer: new ValueComparer<bool>(
            (bool v1, bool v2) => v1 == v2,
            (bool v) => v.GetHashCode(),
            (bool v) => v),
        keyComparer: new ValueComparer<bool>(
            (bool v1, bool v2) => v1 == v2,
            (bool v) => v.GetHashCode(),
            (bool v) => v),
        providerValueComparer: new ValueComparer<bool>(
            (bool v1, bool v2) => v1 == v2,
            (bool v) => v.GetHashCode(),
            (bool v) => v));
    isDeleted.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
    isDeleted.AddAnnotation("Relational:ColumnName", "is_deleted");

    var name = runtimeEntityType.AddProperty(
        "Name",
        typeof(string),
        propertyInfo: typeof(Product).GetProperty("Name", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        fieldInfo: typeof(Product).GetField("<Name>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        maxLength: 50);
    name.TypeMapping = NpgsqlStringTypeMapping.Default.Clone(
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
            storeTypeName: "character varying(50)",
            size: 50));
    name.TypeMapping = ((NpgsqlStringTypeMapping)name.TypeMapping).Clone(npgsqlDbType: NpgsqlTypes.NpgsqlDbType.Varchar);
name.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
name.AddAnnotation("Relational:ColumnName", "name");

var quantity = runtimeEntityType.AddProperty(
    "Quantity",
    typeof(int),
    propertyInfo: typeof(Product).GetProperty("Quantity", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
    fieldInfo: typeof(Product).GetField("<Quantity>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
    valueGenerated: ValueGenerated.OnAdd,
    sentinel: 0);
quantity.TypeMapping = IntTypeMapping.Default.Clone(
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
quantity.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
quantity.AddAnnotation("Relational:ColumnName", "quantity");
quantity.AddAnnotation("Relational:DefaultValue", 0);

var status = runtimeEntityType.AddProperty(
    "Status",
    typeof(ProductStatus),
    propertyInfo: typeof(Product).GetProperty("Status", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
    fieldInfo: typeof(Product).GetField("<Status>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
status.TypeMapping = ByteTypeMapping.Default.Clone(
    comparer: new ValueComparer<ProductStatus>(
        (ProductStatus v1, ProductStatus v2) => object.Equals((object)v1, (object)v2),
        (ProductStatus v) => v.GetHashCode(),
        (ProductStatus v) => v),
    keyComparer: new ValueComparer<ProductStatus>(
        (ProductStatus v1, ProductStatus v2) => object.Equals((object)v1, (object)v2),
        (ProductStatus v) => v.GetHashCode(),
        (ProductStatus v) => v),
    providerValueComparer: new ValueComparer<byte>(
        (byte v1, byte v2) => v1 == v2,
        (byte v) => (int)v,
        (byte v) => v),
    mappingInfo: new RelationalTypeMappingInfo(
        storeTypeName: "smallint"),
    converter: new ValueConverter<ProductStatus, byte>(
        (ProductStatus value) => (byte)value,
        (byte value) => (ProductStatus)value),
    jsonValueReaderWriter: new JsonConvertedValueReaderWriter<ProductStatus, byte>(
        JsonByteReaderWriter.Instance,
        new ValueConverter<ProductStatus, byte>(
            (ProductStatus value) => (byte)value,
            (byte value) => (ProductStatus)value)));
status.SetSentinelFromProviderValue((byte)0);
status.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
status.AddAnnotation("Relational:ColumnName", "status");

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
updateDate.AddAnnotation("Relational:DefaultValue", new DateTime(2024, 5, 15, 17, 49, 26, 120, DateTimeKind.Utc).AddTicks(9860));

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
version.AddAnnotation("Relational:DefaultValue", new Guid("7988cad0-8c68-4fbe-8ca1-848723ec98a5"));

var key = runtimeEntityType.AddKey(
    new[] { id });
runtimeEntityType.SetPrimaryKey(key);
key.AddAnnotation("Relational:Name", "pk_products");

var index = runtimeEntityType.AddIndex(
    new[] { categoryId });
index.AddAnnotation("Relational:Name", "ix_products_category_id");

return runtimeEntityType;
}

public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
{
    var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("CategoryId") },
        principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
        principalEntityType,
        deleteBehavior: DeleteBehavior.SetNull);

    var category = declaringEntityType.AddNavigation("Category",
        runtimeForeignKey,
        onDependent: true,
        typeof(Category),
        propertyInfo: typeof(Product).GetProperty("Category", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        fieldInfo: typeof(Product).GetField("<Category>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        eagerLoaded: true);

    var products = principalEntityType.AddNavigation("Products",
        runtimeForeignKey,
        onDependent: false,
        typeof(ICollection<Product>),
        propertyInfo: typeof(Category).GetProperty("Products", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        fieldInfo: typeof(Category).GetField("<Products>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

    runtimeForeignKey.AddAnnotation("Relational:Name", "fk_products_categories_category_id");
    return runtimeForeignKey;
}

public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
{
    runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
    runtimeEntityType.AddAnnotation("Relational:Schema", null);
    runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
    runtimeEntityType.AddAnnotation("Relational:TableName", "products");
    runtimeEntityType.AddAnnotation("Relational:ViewName", null);
    runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

    Customize(runtimeEntityType);
}

static partial void Customize(RuntimeEntityType runtimeEntityType);
}
}
