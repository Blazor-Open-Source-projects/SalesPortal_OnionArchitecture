using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SalesPortal.Api.Persistence.WebApi.Controller;
[ApiController]
[Route("api/[Controller]")]
public class BaseController: ControllerBase
{
    public Guid? CompanyId
    {
        get
        {
            var companyIdString = HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(companyIdString, out var companyId))
            {
                return companyId;
            }
            return null;
        }
    }
    
}
