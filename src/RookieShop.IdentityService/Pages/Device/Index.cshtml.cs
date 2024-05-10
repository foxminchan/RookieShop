// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using Duende.IdentityServer;
using Duende.IdentityServer.Configuration;
using Duende.IdentityServer.Events;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using RookieShop.IdentityService.Pages.Consent;

namespace RookieShop.IdentityService.Pages.Device;

[SecurityHeaders]
[Authorize]
public sealed class Index(
    IDeviceFlowInteractionService interaction,
    IEventService eventService,
    IOptions<IdentityServerOptions> options,
    ILogger<Index> logger) : PageModel
{
    public IOptions<IdentityServerOptions> Options { get; } = options;

    public ViewModel View { get; set; } = default!;

    [BindProperty] public InputModel Input { get; set; } = default!;

    public async Task<IActionResult> OnGet(string? userCode)
    {
        logger.LogDebug("Identity options: {@Options}", Options.Value);

        if (string.IsNullOrWhiteSpace(userCode)) return Page();

        if (!await SetViewModelAsync(userCode))
        {
            ModelState.AddModelError("", DeviceOptions.InvalidUserCode);
            return Page();
        }

        Input = new InputModel
        {
            UserCode = userCode
        };

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        var request =
            await interaction.GetAuthorizationContextAsync(Input.UserCode ??
#pragma warning disable S3928
                                                           throw new ArgumentNullException(nameof(Input.UserCode)));
#pragma warning restore S3928
        if (request == null) return RedirectToPage("/Home/Error/Index");

        ConsentResponse? grantedConsent = null;

        logger.LogInformation("User clicked '{Button}' for device flow consent for request with user code '{Code}'",
            Input.Button, Input.UserCode);

        switch (Input.Button)
        {
            // user clicked 'no' - send back the standard 'access_denied' response
            case "no":
                grantedConsent = new ConsentResponse
                {
                    Error = AuthorizationError.AccessDenied
                };

                // emit event
                await eventService.RaiseAsync(new ConsentDeniedEvent(User.GetSubjectId(), request.Client.ClientId,
                    request.ValidatedResources.RawScopeValues));
                Telemetry.Metrics.ConsentDenied(request.Client.ClientId,
                    request.ValidatedResources.ParsedScopes.Select(s => s.ParsedName));
                break;
            // user clicked 'yes' - validate the data
            // if the user consented to some scope, build the response model
            case "yes" when Input.ScopesConsented.Any():
            {
                var scopes = Input.ScopesConsented;
                if (!ConsentOptions.EnableOfflineAccess)
                    scopes = scopes.Where(x => x != IdentityServerConstants.StandardScopes.OfflineAccess);

                grantedConsent = new ConsentResponse
                {
                    RememberConsent = Input.RememberConsent,
                    ScopesValuesConsented = scopes.ToArray(),
                    Description = Input.Description
                };

                // emit event
                await eventService.RaiseAsync(new ConsentGrantedEvent(User.GetSubjectId(), request.Client.ClientId,
                    request.ValidatedResources.RawScopeValues, grantedConsent.ScopesValuesConsented,
                    grantedConsent.RememberConsent));
                Telemetry.Metrics.ConsentGranted(request.Client.ClientId, grantedConsent.ScopesValuesConsented,
                    grantedConsent.RememberConsent);
                var denied = request.ValidatedResources.ParsedScopes.Select(s => s.ParsedName)
                    .Except(grantedConsent.ScopesValuesConsented);
                Telemetry.Metrics.ConsentDenied(request.Client.ClientId, denied);
                break;
            }
            case "yes":
                ModelState.AddModelError("", ConsentOptions.MustChooseOneErrorMessage);
                break;
            default:
                ModelState.AddModelError("", ConsentOptions.InvalidSelectionErrorMessage);
                break;
        }

        if (grantedConsent is not null)
        {
            // communicate outcome of consent back to identity-server
            await interaction.HandleRequestAsync(Input.UserCode, grantedConsent);

            // indicate that's it ok to redirect back to authorization endpoint
            return RedirectToPage("/Device/Success");
        }

        // we need to redisplay the consent UI
        if (!await SetViewModelAsync(Input.UserCode)) return RedirectToPage("/Home/Error/Index");
        return Page();
    }


    private async Task<bool> SetViewModelAsync(string userCode)
    {
        var request = await interaction.GetAuthorizationContextAsync(userCode);
        if (request is not null)
        {
            View = CreateConsentViewModel(request);
            return true;
        }

        View = new ViewModel();
        return false;
    }

    private ViewModel CreateConsentViewModel(DeviceFlowAuthorizationRequest request)
    {
        var vm = new ViewModel
        {
            ClientName = request.Client.ClientName ?? request.Client.ClientId,
            ClientUrl = request.Client.ClientUri,
            ClientLogoUrl = request.Client.LogoUri,
            AllowRememberConsent = request.Client.AllowRememberConsent,
            IdentityScopes = request.ValidatedResources.Resources.IdentityResources.Select(x =>
                CreateScopeViewModel(x, Input.ScopesConsented.Contains(x.Name))).ToArray()
        };

        var apiScopes = new List<ScopeViewModel>();
        foreach (var parsedScope in request.ValidatedResources.ParsedScopes)
        {
            var apiScope = request.ValidatedResources.Resources.FindApiScope(parsedScope.ParsedName);
            if (apiScope is null) continue;
            var scopeVm = CreateScopeViewModel(parsedScope, apiScope,
                Input == null || Input.ScopesConsented.Contains(parsedScope.RawValue));
            apiScopes.Add(scopeVm);
        }

        if (DeviceOptions.EnableOfflineAccess && request.ValidatedResources.Resources.OfflineAccess)
            apiScopes.Add(GetOfflineAccessScope(Input == null ||
                                                Input.ScopesConsented.Contains(IdentityServerConstants.StandardScopes
                                                    .OfflineAccess)));
        vm.ApiScopes = apiScopes;

        return vm;
    }

    private static ScopeViewModel CreateScopeViewModel(IdentityResource identity, bool check) =>
        new()
        {
            Value = identity.Name,
            DisplayName = identity.DisplayName ?? identity.Name,
            Description = identity.Description,
            Emphasize = identity.Emphasize,
            Required = identity.Required,
            Checked = check || identity.Required
        };

    private static ScopeViewModel
        CreateScopeViewModel(ParsedScopeValue parsedScopeValue, ApiScope apiScope, bool check) =>
        new()
        {
            Value = parsedScopeValue.RawValue,
            DisplayName = apiScope.DisplayName ?? apiScope.Name,
            Description = apiScope.Description,
            Emphasize = apiScope.Emphasize,
            Required = apiScope.Required,
            Checked = check || apiScope.Required
        };

    private static ScopeViewModel GetOfflineAccessScope(bool check) =>
        new()
        {
            Value = IdentityServerConstants.StandardScopes.OfflineAccess,
            DisplayName = DeviceOptions.OfflineAccessDisplayName,
            Description = DeviceOptions.OfflineAccessDescription,
            Emphasize = true,
            Checked = check
        };
}