using MediatR;
using SalesPortal.Common.Models.Queries;

namespace SalesPortal.Common.Models.RequestModels;

public class LoginCompanyCommand : IRequest<LoginCompanyViewModel>
{
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}
