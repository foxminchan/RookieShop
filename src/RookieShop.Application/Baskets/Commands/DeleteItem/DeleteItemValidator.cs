﻿using FluentValidation;

namespace RookieShop.Application.Baskets.Commands.DeleteItem;

public sealed class DeleteItemValidator : AbstractValidator<DeleteItemCommand>
{
    public DeleteItemValidator()
    {
        RuleFor(x => x.AccountId)
            .NotEmpty();

        RuleFor(x => x.ProductId)
            .NotEmpty();
    }
}