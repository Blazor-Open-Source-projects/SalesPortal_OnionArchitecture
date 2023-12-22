using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SalesPortal.WebApp.Infrastructure.Extensions;
using System.Security.Claims;

namespace SalesPortal.WebApp.Infrastructure.auth;

public class AuthStateProvider : AuthenticationStateProvider
{
    private readonly AuthenticationState anonymous;
    private readonly ILocalStorageService localStorageService;

    public AuthStateProvider(AuthenticationState state, ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
        anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var apiToken = await localStorageService.GetTokenAsync();

        if (string.IsNullOrEmpty(apiToken))
            return anonymous;
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.ReadJwtToken(apiToken);

        var cp = new ClaimsPrincipal(new ClaimsIdentity(securityToken.Claims,"jwtAuthType"));

        return new AuthenticationState(cp);
    }

    public void NotifyCompanyLogin(string companyName, Guid id)
    {
        var cp = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, companyName),
            new Claim(ClaimTypes.NameIdentifier, id.ToString()),

        }, "jwtAuthType"));

        var authState = Task.FromResult(new AuthenticationState(cp));

        NotifyAuthenticationStateChanged(authState);
    }
    public void NotifyCompanyLogout()
    {
        var authState = Task.FromResult(anonymous);

        NotifyAuthenticationStateChanged(authState);
    }
}
