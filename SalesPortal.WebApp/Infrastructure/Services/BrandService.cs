using SalesPortal.Common.Models.Queries;
using System.Net.Http.Json;

namespace SalesPortal.WebApp.Infrastructure.Services.Interfaces
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient httpClient;

        public BrandService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<GetBrandsViewModel>> GetAll()
        {
            var result = await httpClient.GetFromJsonAsync<List<GetBrandsViewModel>>("/api/Brand");
            return result;
        }
    }
}
