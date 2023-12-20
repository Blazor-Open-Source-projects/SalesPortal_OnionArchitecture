using SalesPortal.Common.Models.Page;
using SalesPortal.Common.Models.Queries;
using SalesPortal.Common.Models.RequestModels;
using SalesPortal.WebApp.Infrastructure.Services.Interfaces;

namespace SalesPortal.WebApp.Infrastructure.Services;

public class EnvanterService : IEnvanterService
{
    private readonly HttpClient httpClient;

    public EnvanterService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public Task<Guid> Create(CreateEnvanterCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(UpdateEnvanterCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<PagedViewModel<GetEnvantersViewModel>> GetEnvaters(int page, int pageSize)
    {
        throw new NotImplementedException();
    }
}
