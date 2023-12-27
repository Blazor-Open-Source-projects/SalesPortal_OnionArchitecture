﻿using SalesPortal.Common.Models.Page;
using SalesPortal.Common.Models.Queries;
using SalesPortal.Common.Models.RequestModels;
using SalesPortal.WebApp.Infrastructure.Services.Interfaces;
using System.Net.Http.Json;

namespace SalesPortal.WebApp.Infrastructure.Services;

public class EnvanterService : IEnvanterService
{
    private readonly HttpClient httpClient;

    public EnvanterService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<Guid> Create(CreateEnvanterCommand command)
    {
        var result = await httpClient.PostAsJsonAsync("/api/Envanter", command); 
        
        if(!result.IsSuccessStatusCode)
            return Guid.Empty;

        var guidStr = await result.Content.ReadAsStringAsync();

        return new Guid(guidStr.Trim('"'));
    }


    public async Task<PagedViewModel<GetEnvantersViewModel>> GetEnvaters(int page, int pageSize)
    {
        var result =await httpClient.GetFromJsonAsync<PagedViewModel<GetEnvantersViewModel>>($"/api/Envanter?page={page}&pageSize={pageSize}");
        return result;
    }
}
