﻿using Ardalis.GuardClauses;
using RookieShop.Domain.Entities.CustomerAggregator.Enums;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.Entities.OrderAggregator;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.CustomerAggregator;

public sealed class Customer : EntityBase, ISoftDelete, IAggregateRoot
{
    /// <summary>
    ///     EF mapping constructor
    /// </summary>
    public Customer()
    {
    }

    public Customer(string name, string email, string phone, Gender gender, Guid? accountId)
    {
        Name = Guard.Against.NullOrEmpty(name);
        Email = Guard.Against.NullOrEmpty(email);
        Phone = Guard.Against.NullOrEmpty(phone);
        Gender = Guard.Against.EnumOutOfRange(gender);
        AccountId = accountId;
    }

    public CustomerId Id { get; set; } = new(Guid.NewGuid());
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.Male;
    public Guid? AccountId { get; set; }
    public ICollection<Order>? Orders { get; set; } = [];
    public ICollection<Feedback>? Feedbacks { get; set; } = [];
    public bool IsDeleted { get; set; }

    public void Delete() => IsDeleted = true;

    public void Update(string name, string email, string phone, Gender gender, Guid? accountId)
    {
        Name = Guard.Against.NullOrEmpty(name);
        Email = Guard.Against.NullOrEmpty(email);
        Phone = Guard.Against.NullOrEmpty(phone);
        Gender = Guard.Against.EnumOutOfRange(gender);
        AccountId = accountId;
    }
}