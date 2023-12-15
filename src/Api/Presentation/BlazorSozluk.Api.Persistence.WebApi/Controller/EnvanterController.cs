using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesPortal.Common.Models.RequestModels;

namespace BlazorSozluk.Api.Persistence.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvanterController : ControllerBase
    {
        private readonly IMediator mediator;
        public EnvanterController(IMediator mediator)
        {
            this.mediator = mediator;   
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEnvanterCommand command)
        {
            var result =await mediator.Send(command);

            return Ok(result);
        }
    }
}
