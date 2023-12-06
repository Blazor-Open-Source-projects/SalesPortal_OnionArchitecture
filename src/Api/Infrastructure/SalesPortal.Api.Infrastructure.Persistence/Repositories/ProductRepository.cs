using Microsoft.EntityFrameworkCore;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Api.Domain.Models;
using SalesPortal.Api.Infrastructure.Persistence.Context;

namespace SalesPortal.Api.Infrastructure.Persistence.Repositories;

public class ProductRepository : GenericRepository<SalesProduct>, IProductRepository    
{
    public ProductRepository(ApplicationContext context) : base(context)
    {
    }
}
