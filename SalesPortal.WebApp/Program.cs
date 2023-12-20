using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SalesPortal.WebApp;
using SalesPortal.WebApp.Infrastructure.Services;
using SalesPortal.WebApp.Infrastructure.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddHttpClient("WebApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001");
});
//.AddHttpMessageHandler<AuthTokenHandler>();     
//TODO AuthTokenHandler

builder.Services.AddScoped(sp =>
{
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
    return clientFactory.CreateClient("WebApiClient");
});


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#region service Instances

builder.Services.AddScoped<IEnvanterService, EnvanterService>();

#endregion

builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();
