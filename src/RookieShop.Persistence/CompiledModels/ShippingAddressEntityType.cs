﻿// <auto-generated />
using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using RookieShop.Domain.Entities.OrderAggregator;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;
using RookieShop.Domain.Entities.OrderAggregator.ValueObjects;

#pragma warning disable 219, 612, 618
#nullable disable

namespace RookieShop.Persistence.CompiledModels
{
    internal partial class ShippingAddressEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "RookieShop.Domain.Entities.OrderAggregator.ValueObjects.ShippingAddress",
                typeof(ShippingAddress),
                baseEntityType);

            var orderId = runtimeEntityType.AddProperty(
                "OrderId",
                typeof(OrderId),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);
            orderId.TypeMapping = GuidTypeMapping.Default.Clone(
                comparer: new ValueComparer<OrderId>(
                    (OrderId v1, OrderId v2) => v1.Equals(v2),
                    (OrderId v) => v.GetHashCode(),
                    (OrderId v) => v),
                keyComparer: new ValueComparer<OrderId>(
                    (OrderId v1, OrderId v2) => v1.Equals(v2),
                    (OrderId v) => v.GetHashCode(),
                    (OrderId v) => v),
                providerValueComparer: new ValueComparer<Guid>(
                    (Guid v1, Guid v2) => v1 == v2,
                    (Guid v) => v.GetHashCode(),
                    (Guid v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "uuid"),
                converter: new ValueConverter<OrderId, Guid>(
                    (OrderId id) => id.Value,
                    (Guid value) => new OrderId(value)),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<OrderId, Guid>(
                    JsonGuidReaderWriter.Instance,
                    new ValueConverter<OrderId, Guid>(
                        (OrderId id) => id.Value,
                        (Guid value) => new OrderId(value))));
            orderId.SetSentinelFromProviderValue(new Guid("00000000-0000-0000-0000-000000000000"));
            orderId.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            orderId.AddAnnotation("Relational:ColumnName", "id");

            var city = runtimeEntityType.AddProperty(
                "City",
                typeof(string),
                propertyInfo: typeof(ShippingAddress).GetProperty("City", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ShippingAddress).GetField("<City>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 50);
            city.TypeMapping = NpgsqlStringTypeMapping.Default.Clone(
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
            city.TypeMapping = ((NpgsqlStringTypeMapping)city.TypeMapping).Clone(npgsqlDbType: NpgsqlTypes.NpgsqlDbType.Varchar);
        city.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        city.AddAnnotation("Relational:ColumnName", "shipping_address_city");

        var province = runtimeEntityType.AddProperty(
            "Province",
            typeof(string),
            propertyInfo: typeof(ShippingAddress).GetProperty("Province", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            fieldInfo: typeof(ShippingAddress).GetField("<Province>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
            nullable: true,
            maxLength: 50);
        province.TypeMapping = NpgsqlStringTypeMapping.Default.Clone(
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
        province.TypeMapping = ((NpgsqlStringTypeMapping)province.TypeMapping).Clone(npgsqlDbType: NpgsqlTypes.NpgsqlDbType.Varchar);
    province.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
    province.AddAnnotation("Relational:ColumnName", "shipping_address_province");

    var street = runtimeEntityType.AddProperty(
        "Street",
        typeof(string),
        propertyInfo: typeof(ShippingAddress).GetProperty("Street", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        fieldInfo: typeof(ShippingAddress).GetField("<Street>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        nullable: true,
        maxLength: 50);
    street.TypeMapping = NpgsqlStringTypeMapping.Default.Clone(
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
    street.TypeMapping = ((NpgsqlStringTypeMapping)street.TypeMapping).Clone(npgsqlDbType: NpgsqlTypes.NpgsqlDbType.Varchar);
street.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
street.AddAnnotation("Relational:ColumnName", "shipping_address_street");

var key = runtimeEntityType.AddKey(
    new[] { orderId });
runtimeEntityType.SetPrimaryKey(key);

return runtimeEntityType;
}

public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
{
    var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("OrderId") },
        principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
        principalEntityType,
        deleteBehavior: DeleteBehavior.Cascade,
        unique: true,
        required: true,
        ownership: true);

    var shippingAddress = principalEntityType.AddNavigation("ShippingAddress",
        runtimeForeignKey,
        onDependent: false,
        typeof(ShippingAddress),
        propertyInfo: typeof(Order).GetProperty("ShippingAddress", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        fieldInfo: typeof(Order).GetField("<ShippingAddress>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
        propertyAccessMode: PropertyAccessMode.Property,
        eagerLoaded: true);

    runtimeForeignKey.AddAnnotation("Relational:Name", "fk_orders_orders_id");
    return runtimeForeignKey;
}

public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
{
    runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
    runtimeEntityType.AddAnnotation("Relational:Schema", null);
    runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
    runtimeEntityType.AddAnnotation("Relational:TableName", "orders");
    runtimeEntityType.AddAnnotation("Relational:ViewName", null);
    runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

    Customize(runtimeEntityType);
}

static partial void Customize(RuntimeEntityType runtimeEntityType);
}
}