using Blazored.LocalStorage;
using SalesPortal.WebApp.Infrastructure.Extensions;
using System.Net.Http.Headers;

namespace SalesPortal.WebApp.Infrastructure.auth;

public class AuthTokenHandler : DelegatingHandler
{
    private readonly ISyncLocalStorageService localStorageService;

    public AuthTokenHandler(ISyncLocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }
    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = localStorageService.GetToken();

        if (!string.IsNullOrEmpty(token) && request.Headers.Authorization == null)
            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
        return base.Send(request, cancellationToken);
    }
}
