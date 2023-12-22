namespace SalesPortal.Common.Models.Queries;

public class LoginCompanyViewModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyName { get; set; }

    public string Token { get; set; }
}
