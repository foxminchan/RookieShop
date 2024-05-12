using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RookieShop.IdentityService.Models;

namespace RookieShop.IdentityService.Pages.Account.Register;

[SecurityHeaders]
[AllowAnonymous]
public sealed class Index(UserManager<ApplicationUser> userManager) : PageModel
{
    [BindProperty] public InputModel Input { get; set; } = default!;

    public async Task<IActionResult> OnGet(string? returnUrl)
    {
        Input = new()
        {
            ReturnUrl = returnUrl
        };

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (Input.Button != "register")
            return RedirectToPage("/Account/Login/Index", new { returnUrl = Input.ReturnUrl });

        if (!ModelState.IsValid)
            return Page();

        if (Input.Username is null || Input.Password is null || Input.PhoneNumber is null)
            return Page();

        var user = await userManager.FindByNameAsync(Input.Username);

        if (user is not null)
        {
            ModelState.AddModelError("Username", "Username is already taken");
            return Page();
        }

        user = new()
        {
            UserName = Input.Username,
            PhoneNumber = Input.PhoneNumber
        };

        var result = await userManager.CreateAsync(user, Input.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }

        await userManager.AddToRoleAsync(user, "user");

        return RedirectToPage("/Account/Login/Index", new { returnUrl = Input.ReturnUrl });
    }
}