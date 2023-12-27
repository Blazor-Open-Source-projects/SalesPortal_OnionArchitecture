using SalesPortal.Common.Models.Queries;

namespace SalesPortal.WebApp.Infrastructure.Services.Interfaces;

public interface IBrandService 
{
    Task<List<GetBrandsViewModel>> GetAll();
}
