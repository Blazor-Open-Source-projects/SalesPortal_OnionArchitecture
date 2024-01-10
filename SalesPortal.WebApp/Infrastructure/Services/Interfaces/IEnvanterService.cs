using SalesPortal.Common.Models.Page;
using SalesPortal.Common.Models.Queries;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.WebApp.Infrastructure.Services.Interfaces;

public interface IEnvanterService
{
    Task<bool> Update(Guid envanterId, UpdateEnvanterCommand command);
    Task<Guid> Create(CreateEnvanterCommand command);
    Task<bool> Delete(Guid envanterId);
    Task<PagedViewModel<GetEnvantersViewModel>> GetEnvaters(int page, int pageSize);
    Task<CreateEnvanterCommand> GetEnvanter(Guid id);
}
