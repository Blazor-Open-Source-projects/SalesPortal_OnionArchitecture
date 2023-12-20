using MediatR;

namespace SalesPortal.Common.Models.RequestModels;

public class CreateCompanyCommand : IRequest<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}
