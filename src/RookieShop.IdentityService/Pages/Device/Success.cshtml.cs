// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RookieShop.IdentityService.Pages.Device;

[SecurityHeaders]
[Authorize]
public sealed class SuccessModel : PageModel;