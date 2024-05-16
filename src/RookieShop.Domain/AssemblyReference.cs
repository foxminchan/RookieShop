using System.Reflection;

namespace RookieShop.Domain;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    public static readonly Assembly Executing = Assembly.GetExecutingAssembly();
}