using SalesPortal.Common.Models.Page;
using SalesPortal.Common.Models.Queries;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.WebApp.Infrastructure.Services.Interfaces;

public interface IEnvanterService
{
    Task<Guid> Create(CreateEnvanterCommand command);
    Task<bool> Create(UpdateEnvanterCommand command);
    Task<PagedViewModel<GetEnvantersViewModel>> GetEnvaters(int page, int pageSize);
}
