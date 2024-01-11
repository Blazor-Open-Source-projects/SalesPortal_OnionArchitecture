using SalesPortal.Common.Models.Queries;
using SalesPortal.WebApp.Infrastructure.Services.Interfaces;
using System.Net.Http.Json;

namespace SalesPortal.WebApp.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient httpClient;

        public CategoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<GetCategoryViewModel>> GetCategories()
        {
            return await httpClient.GetFromJsonAsync<List<GetCategoryViewModel>>("/api/Category");
        }
    }
}
