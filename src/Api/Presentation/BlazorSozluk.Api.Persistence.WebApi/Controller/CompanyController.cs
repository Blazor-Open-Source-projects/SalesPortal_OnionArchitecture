using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesPortal.Api.Application.Features.Commands.Company.Login;
using SalesPortal.Common.Models.RequestModels;

namespace BlazorSozluk.Api.Persistence.WebApi.Controller;

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
    public async Task<ActionResult> Create(CreateCompanyCommand command)
    {
        var result =await mediator.Send(command);

        return Ok(result);
    }


    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginCompanyCommand command)
    {
        var guid = await mediator.Send(command);
        return Ok(guid);
    }
}
