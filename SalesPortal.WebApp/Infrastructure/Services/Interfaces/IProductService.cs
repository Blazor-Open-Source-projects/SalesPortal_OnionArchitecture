using SalesPortal.Common.Models.Page;
using SalesPortal.Common.Models.Queries;

namespace SalesPortal.WebApp.Infrastructure.Services.Interfaces;

public interface IProductService
{
    Task<PagedViewModel<GetProductViewModel>> GetProducts(int page, int pageSize);
}
