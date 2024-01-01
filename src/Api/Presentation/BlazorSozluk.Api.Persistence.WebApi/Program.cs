using SalesPortal.Api.Infrastructure.Persistence.Extensions;
using SalesPortal.Api.Application.Extensions;
using SalesPortal.Api.Persistence.WebApi.Infrastructure.ActionFilter;
using SalesPortal.Api.Infrastructure.Persistence.Context;
using SalesPortal.Api.Persistence.WebApi.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt => opt.Filters.Add<ValidationModelStateFilter>());


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "SalesPortal.API", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                    new OpenApiSecurityScheme
                    {                                             
                         Reference = new OpenApiReference
                         {                  
                            Type = ReferenceType.SecurityScheme,                    
                            Id = "Bearer"                    
                         }                   
                    },
                new string[] {}
            }
        });
});


builder.Services.ConfigureAuth(builder.Configuration);

builder.Services.AddInfrastructureRegistration(builder.Configuration);
builder.Services.AddApplicationRegistration();

builder.Services.AddCors(opt => opt.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
}));

var app = builder.Build();

Seed.SeedData(builder.Configuration);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureExceptionHandling(app.Environment.IsDevelopment());

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("MyPolicy");
app.MapControllers();

app.Run();
