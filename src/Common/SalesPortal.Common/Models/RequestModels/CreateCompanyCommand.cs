using MediatR;
using System.ComponentModel.DataAnnotations;

namespace SalesPortal.Common.Models.RequestModels;

public class CreateCompanyCommand : IRequest<Guid>
{ 
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string CompanyName { get; set; }
    [EmailAddress]
    public string EmailAddress { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Compare("Password")]
    public string PasswordControl { get; set; }
}
