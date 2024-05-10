// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Identity;

namespace RookieShop.IdentityService.Models;

#pragma warning disable S2094 // Classes should not be empty
public sealed class ApplicationUser : IdentityUser;
#pragma warning restore S2094 // Classes should not be empty