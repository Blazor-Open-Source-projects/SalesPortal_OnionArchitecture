using SalesPortal.Common.Models.Page;
using SalesPortal.Common.Models.Queries;
using SalesPortal.Common.Models.RequestModels;
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

    public async Task<Guid> Create(CreateProductCommand command)
    {
        var res =await httpClient.PostAsJsonAsync("/api/product", command);

        if(!res.IsSuccessStatusCode)
            return Guid.Empty;
        var guidStr = await res.Content.ReadAsStringAsync();

        return new Guid(guidStr.Trim('"'));
    }

    public async Task<bool> DeleteProduct(Guid productId)
    {
        var res = await httpClient.PostAsync($"/api/product/delete?productId={productId}",null);

        if (!res.IsSuccessStatusCode)
            return false;

        return true;

    }

    public async Task<CreateProductCommand> GetProductById(Guid productId)
    {
       return await httpClient.GetFromJsonAsync<CreateProductCommand>($"/api/product/{productId}");
    }

    public async Task<PagedViewModel<GetProductViewModel>> GetProducts(int page, int pageSize)
    {
        return await httpClient.GetFromJsonAsync<PagedViewModel<GetProductViewModel>>($"/api/product?page={page}&pageSize={pageSize}");
    }

    public async Task<bool> UpdateProducts(UpdateProductCommand command)
    {
        var res = await httpClient.PostAsJsonAsync("/api/Product/update", command);

        return await res.Content.ReadFromJsonAsync<bool>();
    }
}
