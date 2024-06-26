﻿using System.Reflection;

namespace RookieShop.Application;

public static class AssemblyReference
{
    public static readonly Assembly Executing = Assembly.GetExecutingAssembly();
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}