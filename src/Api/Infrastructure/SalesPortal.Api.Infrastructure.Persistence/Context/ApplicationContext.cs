using Microsoft.EntityFrameworkCore;
using SalesPortal.Api.Domain.Models;

namespace SalesPortal.Api.Infrastructure.Persistence.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Envanter> Envanters { get; set; }  
    public DbSet<SalesProduct> SalesProducts { get; set; }
    public DbSet<SalesUnit> SalesUnits { get; set; }

}
