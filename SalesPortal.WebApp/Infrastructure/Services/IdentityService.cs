using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SalesPortal.Common.Infrastructure.Exceptions;
using SalesPortal.Common.Infrastructure.Results;
using SalesPortal.Common.Models.Queries;
using SalesPortal.Common.Models.RequestModels;
using SalesPortal.WebApp.Infrastructure.auth;
using SalesPortal.WebApp.Infrastructure.Extensions;
using SalesPortal.WebApp.Infrastructure.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace SalesPortal.WebApp.Infrastructure.Services;

public class IdentityService : IIdentityService
{
    private readonly HttpClient httpClient;
    private readonly ISyncLocalStorageService localStorageService;
    private readonly AuthenticationStateProvider authenticationStateProvider;

    public IdentityService(HttpClient httpClient, ISyncLocalStorageService localStorageService,
        AuthenticationStateProvider authenticationStateProvider)
    {
        this.httpClient = httpClient;
        this.localStorageService = localStorageService;
        this.authenticationStateProvider = authenticationStateProvider;
    }

    public bool IsLoggedId => !string.IsNullOrEmpty(GetUserToken());
    
    private string GetUserToken()
    {
        return localStorageService.GetToken();
    }

    public async Task<bool> Login(LoginCompanyCommand command)
    {
        string responseStr;
        var httpResponse =await httpClient.PostAsJsonAsync("/api/Company/login", command);

        if(httpResponse != null && !httpResponse.IsSuccessStatusCode)
        {
            if(httpResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                responseStr = await httpResponse.Content.ReadAsStringAsync();
                var validation = JsonSerializer.Deserialize<ValidationResponseModel>(responseStr);
                responseStr = validation.FlattenErrors;
                throw new DatabaseValidationException(responseStr);
            }
            return false;
        }

        var response = await httpResponse.Content.ReadFromJsonAsync<LoginCompanyViewModel>();


        if(!string.IsNullOrEmpty(response.Token))
        {

            localStorageService.SetToken(response.Token);
            localStorageService.SetCompanyId(response.Id);
            localStorageService.SetCompanyName(response.CompanyName);

            ((AuthStateProvider)authenticationStateProvider).NotifyCompanyLogin(response.CompanyName,response.Id);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", response.Token);

            return true;

        }
        return false;
    }

    public async Task Logout()
    {
        localStorageService.RemoveItem(LocalStorageExtension.TokenName);
        localStorageService.RemoveItem(LocalStorageExtension.CompanyId);
        localStorageService.RemoveItem(LocalStorageExtension.CompanyName);

        ((AuthStateProvider)authenticationStateProvider).NotifyCompanyLogout();

        httpClient.DefaultRequestHeaders.Authorization = null;

    }
}
