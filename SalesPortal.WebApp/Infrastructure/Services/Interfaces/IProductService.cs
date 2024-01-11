using SalesPortal.Common.Models.Page;
using SalesPortal.Common.Models.Queries;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.WebApp.Infrastructure.Services.Interfaces;

public interface IProductService
{
    Task<PagedViewModel<GetProductViewModel>> GetProducts(int page, int pageSize);
    Task<bool> UpdateProducts(UpdateProductCommand command);
    Task<bool> DeleteProduct(Guid productId);
    Task<CreateProductCommand> GetProductById(Guid productId);
    Task<Guid> Create(CreateProductCommand command);
}
