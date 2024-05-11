using System.Reflection;

namespace RookieShop.ApiService;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}