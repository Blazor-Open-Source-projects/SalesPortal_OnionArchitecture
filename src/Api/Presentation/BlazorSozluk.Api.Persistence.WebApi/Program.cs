using SalesPortal.Api.Infrastructure.Persistence.Extensions;
using SalesPortal.Api.Application.Extensions;
using BlazorSozluk.Api.Persistence.WebApi.Infrastructure.ActionFilter;
using SalesPortal.Api.Infrastructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt => opt.Filters.Add<ValidationModelStateFilter>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureRegistration(builder.Configuration);
builder.Services.AddApplicationRegistration();
var app = builder.Build();

Seed.SeedData(builder.Configuration);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
