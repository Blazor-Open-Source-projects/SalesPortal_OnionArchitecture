using Microsoft.EntityFrameworkCore;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Api.Domain.Models;
using SalesPortal.Api.Infrastructure.Persistence.Context;

namespace SalesPortal.Api.Infrastructure.Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationContext context) : base(context)
    {
    }
}
