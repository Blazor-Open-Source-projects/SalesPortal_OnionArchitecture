using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesPortal.Api.Domain.Models;
using SalesPortal.Common.Infrastructure;

namespace SalesPortal.Api.Infrastructure.Persistence.Context;

public static class Seed
{
    public static void SeedData(IConfiguration configuration)
    {
        
        var dbContextBuilder = new DbContextOptionsBuilder();
        dbContextBuilder.UseSqlServer(configuration.GetConnectionString("SalesPortalConnectionString"));

        var context = new ApplicationContext(dbContextBuilder.Options);
        if(!context.Categories.Any())
        {

            var categories = new Faker<Category>()
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.Name, i => i.Vehicle.Manufacturer())
                .Generate(10);

            context.Categories.AddRange(categories);

            var brands = new Faker<Brand>()
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.Name, i => i.Vehicle.Model())
                .Generate(10);

            context.Brands.AddRange(brands);



            var companies = new Faker<Company>()
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                    .RuleFor(i => i.CreatedDate,
                            i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                    .RuleFor(i => i.FirstName, i => i.Person.FirstName)
                    .RuleFor(i => i.LastName, i => i.Person.LastName)
                    .RuleFor(i => i.EmailAddress, i => i.Internet.Email())
                    .RuleFor(i => i.CompanyName, i => i.Company.CompanyName())
                    .RuleFor(i => i.Password, i => PasswordEncrypter.EncryptPassord(i.Internet.Password()))
                    .RuleFor(i => i.EmailConfirmed, i => i.PickRandom(true, false))
            .Generate(10);

            context.Companies.AddRange(companies);

            var companyIds = companies.Select(i => i.Id);

            var envanters = new Faker<Envanter>()
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.Name, i => i.Company.CompanyName())
                .RuleFor(i => i.ENVCode, i => i.Internet.DomainName())
                .RuleFor(i => i.StockQuantity, i => i.Random.Number())
                .RuleFor(i => i.CompanyId, i => i.PickRandom(companyIds))
            .Generate(100);

            context.Envanters.AddRange(envanters);

            context.SaveChanges();

        }
    }
}
