﻿using Microsoft.AspNetCore.Mvc;

namespace RookieShop.Storefront.Areas.User.Controllers;

[Area("User")]
public class UserController : Controller
{
    public IActionResult Index() => View();
}