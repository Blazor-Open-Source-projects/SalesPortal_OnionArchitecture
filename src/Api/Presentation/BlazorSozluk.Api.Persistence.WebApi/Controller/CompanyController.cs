using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.Api.Persistence.WebApi.Controller;

[ApiController]
[Route("api/[Controller]")]
public class CompanyController : ControllerBase
{
    private readonly IMediator mediator;

    public CompanyController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateCompanyCommand command)
    {
        var result =await mediator.Send(command);

        return Ok(result);
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCompanyCommand command)
    {
        var guid = await mediator.Send(command);
        return Ok(guid);
    }
}
