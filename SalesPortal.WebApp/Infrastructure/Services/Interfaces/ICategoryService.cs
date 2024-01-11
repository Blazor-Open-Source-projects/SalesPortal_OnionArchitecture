using SalesPortal.Common.Models.Queries;

namespace SalesPortal.WebApp.Infrastructure.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<GetCategoryViewModel>> GetCategories();
    }
}
