using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.WebApp.Infrastructure.Services.Interfaces;

public interface IIdentityService
{
    bool IsLoggedId { get; }

    Task<bool> Login(LoginCompanyCommand command);
    Task Logout();

}
