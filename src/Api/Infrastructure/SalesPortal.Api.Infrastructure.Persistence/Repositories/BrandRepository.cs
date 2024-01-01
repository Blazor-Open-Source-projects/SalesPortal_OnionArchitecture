using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Api.Domain.Models;
using SalesPortal.Api.Infrastructure.Persistence.Context;

namespace SalesPortal.Api.Infrastructure.Persistence.Repositories;

public class BrandRepository : GenericRepository<Brand>,IBrandRepository
{
    public BrandRepository(ApplicationContext context) : base(context)
    {
    }
}
