using MediatR;
using SalesPortal.Common.Models.Queries;
using System.ComponentModel.DataAnnotations;

namespace SalesPortal.Common.Models.RequestModels;

public class LoginCompanyCommand : IRequest<LoginCompanyViewModel>
{
    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; }
    [Required]
    public string Password { get; set; }
}
