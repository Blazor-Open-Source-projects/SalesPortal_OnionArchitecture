using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlazorSozluk.Api.Persistence.WebApi.Controller;
[ApiController]
[Route("api/[Controller]")]
public class BaseController: ControllerBase
{
    public Guid? CompanyId
    {
        get
        {
            var userIdString = HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userIdString, out var userId))
            {
                return userId;
            }
            return null;
        }
    }
    
}
