using SalesPortal.Common.Models.Page;
using SalesPortal.Common.Models.Queries;
using SalesPortal.WebApp.Infrastructure.Services.Interfaces;
using System.Net.Http.Json;

namespace SalesPortal.WebApp.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly HttpClient httpClient;

    public ProductService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<PagedViewModel<GetProductViewModel>> GetProducts(int page, int pageSize)
    {
        return await httpClient.GetFromJsonAsync<PagedViewModel<GetProductViewModel>>($"/api/product?page={page}&pageSize={pageSize}");
    }
}
