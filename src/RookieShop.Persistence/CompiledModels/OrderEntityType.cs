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
using RookieShop.Domain.Entities.OrderAggregator;
using RookieShop.Domain.Entities.OrderAggregator.Enums;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;
using RookieShop.Domain.SeedWork;

#pragma warning disable 219, 612, 618
#nullable disable

namespace RookieShop.Persistence.CompiledModels
{
    internal partial class OrderEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "RookieShop.Domain.Entities.OrderAggregator.Order",
                typeof(Order),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(OrderId),
                propertyInfo: typeof(Order).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Order).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                propertyAccessMode: PropertyAccessMode.Property,
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);
            id.TypeMapping = GuidTypeMapping.Default.Clone(
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
            id.SetSentinelFromProviderValue(new Guid("00000000-0000-0000-0000-000000000000"));
            id.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            id.AddAnnotation("Relational:ColumnName", "id");
            id.AddAnnotation("Relational:DefaultValueSql", "uuid_generate_v4()");

            var createdDate = runtimeEntityType.AddProperty(
                "CreatedDate",
                typeof(DateTime),
                propertyInfo: typeof(EntityBase).GetProperty("CreatedDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(EntityBase).GetField("<CreatedDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                propertyAccessMode: PropertyAccessMode.Property,
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
            createdDate.AddAnnotation("Relational:DefaultValue", new DateTime(2024, 5, 21, 15, 24, 37, 74, DateTimeKind.Utc).AddTicks(2770));

            var customerId = runtimeEntityType.AddProperty(
                "CustomerId",
                typeof(CustomerId),
                propertyInfo: typeof(Order).GetProperty("CustomerId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Order).GetField("<CustomerId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                propertyAccessMode: PropertyAccessMode.Property);
            customerId.TypeMapping = GuidTypeMapping.Default.Clone(
                comparer: new ValueComparer<CustomerId>(
                    (CustomerId v1, CustomerId v2) => v1.Equals(v2),
                    (CustomerId v) => v.GetHashCode(),
                    (CustomerId v) => v),
                keyComparer: new ValueComparer<CustomerId>(
                    (CustomerId v1, CustomerId v2) => v1.Equals(v2),
                    (CustomerId v) => v.GetHashCode(),
                    (CustomerId v) => v),
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
            customerId.SetSentinelFromProviderValue(new Guid("00000000-0000-0000-0000-000000000000"));
            customerId.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            customerId.AddAnnotation("Relational:ColumnName", "customer_id");

            var orderStatus = runtimeEntityType.AddProperty(
                "OrderStatus",
                typeof(OrderStatus),
                propertyInfo: typeof(Order).GetProperty("OrderStatus", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Order).GetField("<OrderStatus>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                propertyAccessMode: PropertyAccessMode.Property);
            orderStatus.TypeMapping = ByteTypeMapping.Default.Clone(
                comparer: new ValueComparer<OrderStatus>(
                    (OrderStatus v1, OrderStatus v2) => object.Equals((object)v1, (object)v2),
                    (OrderStatus v) => v.GetHashCode(),
                    (OrderStatus v) => v),
                keyComparer: new ValueComparer<OrderStatus>(
                    (OrderStatus v1, OrderStatus v2) => object.Equals((object)v1, (object)v2),
                    (OrderStatus v) => v.GetHashCode(),
                    (OrderStatus v) => v),
                providerValueComparer: new ValueComparer<byte>(
                    (byte v1, byte v2) => v1 == v2,
                    (byte v) => (int)v,
                    (byte v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "smallint"),
                converter: new ValueConverter<OrderStatus, byte>(
                    (OrderStatus value) => (byte)value,
                    (byte value) => (OrderStatus)value),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<OrderStatus, byte>(
                    JsonByteReaderWriter.Instance,
                    new ValueConverter<OrderStatus, byte>(
                        (OrderStatus value) => (byte)value,
                        (byte value) => (OrderStatus)value)));
            orderStatus.SetSentinelFromProviderValue((byte)0);
            orderStatus.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            orderStatus.AddAnnotation("Relational:ColumnName", "order_status");

            var paymentMethod = runtimeEntityType.AddProperty(
                "PaymentMethod",
                typeof(PaymentMethod),
                propertyInfo: typeof(Order).GetProperty("PaymentMethod", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Order).GetField("<PaymentMethod>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                propertyAccessMode: PropertyAccessMode.Property);
            paymentMethod.TypeMapping = ByteTypeMapping.Default.Clone(
                comparer: new ValueComparer<PaymentMethod>(
                    (PaymentMethod v1, PaymentMethod v2) => object.Equals((object)v1, (object)v2),
                    (PaymentMethod v) => v.GetHashCode(),
                    (PaymentMethod v) => v),
                keyComparer: new ValueComparer<PaymentMethod>(
                    (PaymentMethod v1, PaymentMethod v2) => object.Equals((object)v1, (object)v2),
                    (PaymentMethod v) => v.GetHashCode(),
                    (PaymentMethod v) => v),
                providerValueComparer: new ValueComparer<byte>(
                    (byte v1, byte v2) => v1 == v2,
                    (byte v) => (int)v,
                    (byte v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "smallint"),
                converter: new ValueConverter<PaymentMethod, byte>(
                    (PaymentMethod value) => (byte)value,
                    (byte value) => (PaymentMethod)value),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<PaymentMethod, byte>(
                    JsonByteReaderWriter.Instance,
                    new ValueConverter<PaymentMethod, byte>(
                        (PaymentMethod value) => (byte)value,
                        (byte value) => (PaymentMethod)value)));
            paymentMethod.SetSentinelFromProviderValue((byte)0);
            paymentMethod.AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
            paymentMethod.AddAnnotation("Relational:ColumnName", "payment_method");

            var updateDate = runtimeEntityType.AddProperty(
                "UpdateDate",
                typeof(DateTime?),
                propertyInfo: typeof(EntityBase).GetProperty("UpdateDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(EntityBase).GetField("<UpdateDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                propertyAccessMode: PropertyAccessMode.Property,
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
            updateDate.AddAnnotation("Relational:DefaultValue", new DateTime(2024, 5, 21, 15, 24, 37, 74, DateTimeKind.Utc).AddTicks(3227));

            var version = runtimeEntityType.AddProperty(
                "Version",
                typeof(Guid),
                propertyInfo: typeof(EntityBase).GetProperty("Version", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(EntityBase).GetField("<Version>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                propertyAccessMode: PropertyAccessMode.Property,
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
            version.AddAnnotation("Relational:DefaultValue", new Guid("23b2d5d8-5af3-43e5-92dd-1ad74f3c500c"));

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);
            key.AddAnnotation("Relational:Name", "pk_orders");

            var index = runtimeEntityType.AddIndex(
                new[] { customerId });
            index.AddAnnotation("Relational:Name", "ix_orders_customer_id");

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("CustomerId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
                principalEntityType,
                deleteBehavior: DeleteBehavior.Restrict,
                required: true);

            var customer = declaringEntityType.AddNavigation("Customer",
                runtimeForeignKey,
                onDependent: true,
                typeof(Customer),
                propertyInfo: typeof(Order).GetProperty("Customer", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Order).GetField("<Customer>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                propertyAccessMode: PropertyAccessMode.Property,
                eagerLoaded: true);

            var orders = principalEntityType.AddNavigation("Orders",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Order>),
                propertyInfo: typeof(Customer).GetProperty("Orders", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customer).GetField("<Orders>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "fk_orders_customers_customer_id");
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
