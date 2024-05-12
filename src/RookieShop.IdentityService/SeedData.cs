using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RookieShop.Domain.Constants;
using RookieShop.IdentityService.Data;
using RookieShop.IdentityService.Exceptions;
using RookieShop.IdentityService.Models;
using Serilog;

namespace RookieShop.IdentityService;

public static class SeedData
{
    public static void EnsureSeedData(WebApplication app)
    {
        using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();

        var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        var admin = roleMgr.FindByNameAsync("admin").Result;

        if (admin is null)
        {
            admin = new()
            {
                Name = "staff"
            };

            var result = roleMgr.CreateAsync(admin).Result;

            if (!result.Succeeded) throw new SeedException(result.Errors.First().Description);

            roleMgr.AddClaimAsync(admin, new(JwtClaimTypes.Role, AuthScope.Read)).Wait();
            roleMgr.AddClaimAsync(admin, new(JwtClaimTypes.Role, AuthScope.Write)).Wait();

            Log.Debug("staff created");
        }
        else
        {
            Log.Debug("staff already exists");
        }

        var user = roleMgr.FindByNameAsync("user").Result;

        if (user is null)
        {
            user = new()
            {
                Name = "user"
            };

            var result = roleMgr.CreateAsync(user).Result;

            if (!result.Succeeded) throw new SeedException(result.Errors.First().Description);

            roleMgr.AddClaimAsync(user, new(JwtClaimTypes.Role, AuthScope.Read)).Wait();

            Log.Debug("user created");
        }
        else
        {
            Log.Debug("user already exists");
        }

        var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        var nhan = userMgr.FindByNameAsync("nhan").Result;

        if (nhan is null)
        {
            nhan = new()
            {
                UserName = "nhan@gmail.com",
                Email = "nhan@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "1234567890"
            };

            var result = userMgr.CreateAsync(nhan, "NashTech@2024").Result;

            if (!result.Succeeded) throw new SeedException(result.Errors.First().Description);

            result = userMgr.AddClaimsAsync(nhan,
            [
                new(JwtClaimTypes.Name, "Nhan Nguyen"),
                new(JwtClaimTypes.GivenName, "Nhan"),
                new(JwtClaimTypes.FamilyName, "Nguyen"),
                new(JwtClaimTypes.WebSite, "https://github.com/foxminchan")
            ]).Result;

            if (!result.Succeeded) throw new SeedException(result.Errors.First().Description);

            userMgr.AddToRoleAsync(nhan, "staff").Wait();

            if (!result.Succeeded) throw new SeedException(result.Errors.First().Description);

            Log.Debug("nhan created");
        }
        else
        {
            Log.Debug("nhan already exists");
        }

        var fox = userMgr.FindByNameAsync("fox").Result;

        if (fox is null)
        {
            fox = new()
            {
                UserName = "fox@gmail.com",
                Email = "fox@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "1234567890"
            };

            var result = userMgr.CreateAsync(fox, "NashTech@2024").Result;
            if (!result.Succeeded) throw new SeedException(result.Errors.First().Description);

            result = userMgr.AddClaimsAsync(fox,
            [
                new(JwtClaimTypes.Name, "Fox Chan"),
                new(JwtClaimTypes.GivenName, "Fox"),
                new(JwtClaimTypes.FamilyName, "Chan"),
                new(JwtClaimTypes.WebSite, "https://github.com/foxminchan")
            ]).Result;

            if (!result.Succeeded) throw new SeedException(result.Errors.First().Description);

            userMgr.AddToRoleAsync(fox, "user").Wait();

            Log.Debug("fox created");
        }
        else
        {
            Log.Debug("fox already exists");
        }
    }
}