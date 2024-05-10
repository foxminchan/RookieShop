using System.Reflection;

namespace RookieShop.Persistence;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    public static readonly Assembly DbContextAssembly = typeof(ApplicationDbContext).Assembly;
}