﻿using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RookieShop.IdentityService.Constants;
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

        var staff = roleMgr.FindByNameAsync("staff").Result;

        if (staff is null)
        {
            staff = new("admin");

            var result = roleMgr.CreateAsync(staff).Result;

            if (!result.Succeeded) throw new SeedException(result.Errors.First().Description);

            roleMgr.AddClaimAsync(staff, new(JwtClaimTypes.Role, AuthScope.Read)).Wait();
            roleMgr.AddClaimAsync(staff, new(JwtClaimTypes.Role, AuthScope.Write)).Wait();
            roleMgr.AddClaimAsync(staff, new(JwtClaimTypes.Role, AuthScope.All)).Wait();

            Log.Debug("admin created");
        }
        else
        {
            Log.Debug("admin already exists");
        }

        var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        var nhan = userMgr.FindByNameAsync("nhan").Result;

        if (nhan is null)
        {
            nhan = new()
            {
                UserName = "nguyenxuannhan407@gmail.com",
                Email = "nguyenxuannhan407@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "1234567890",
                LockoutEnabled = false
            };

            var result = userMgr.CreateAsync(nhan, "NashTech@2024").Result;

            if (!result.Succeeded) throw new SeedException(result.Errors.First().Description);

            result = userMgr.AddClaimsAsync(nhan,
            [
                new(JwtClaimTypes.PhoneNumber, nhan.PhoneNumber),
                new(JwtClaimTypes.Email, nhan.Email)
            ]).Result;

            if (!result.Succeeded) throw new SeedException(result.Errors.First().Description);

            userMgr.AddToRoleAsync(nhan, "admin").Wait();

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
                UserName = "nguyenxuannhan.dev@gmail.com",
                Email = "nguyenxuannhan.dev@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "1234567890",
                LockoutEnabled = false
            };

            var result = userMgr.CreateAsync(fox, "NashTech@2024").Result;
            if (!result.Succeeded) throw new SeedException(result.Errors.First().Description);

            result = userMgr.AddClaimsAsync(fox,
            [
                new(JwtClaimTypes.PhoneNumber, fox.PhoneNumber),
                new(JwtClaimTypes.Email, fox.Email)
            ]).Result;

            if (!result.Succeeded) throw new SeedException(result.Errors.First().Description);

            Log.Debug("fox created");
        }
        else
        {
            Log.Debug("fox already exists");
        }
    }
}