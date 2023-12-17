using Microsoft.EntityFrameworkCore;
using SalesPortal.Api.Domain.Models;

namespace SalesPortal.Api.Infrastructure.Persistence.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options) : base(options)
    {

    }
    public ApplicationContext()
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesPortal;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(connStr, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        }
    }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Envanter> Envanters { get; set; }  
    public DbSet<SalesProduct> SalesProducts { get; set; }
    public DbSet<SalesUnit> SalesUnits { get; set; }

}
