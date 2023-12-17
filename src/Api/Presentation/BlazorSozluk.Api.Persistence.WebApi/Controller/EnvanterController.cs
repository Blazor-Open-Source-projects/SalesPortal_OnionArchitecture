using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesPortal.Api.Application.Features.Queries.GetEnvanters;
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

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(UpdateEnvanterCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetEnvanters(int page, int pageSize,Guid companyId)
        {
           
            var result = await mediator.Send(new GetEnvanterQuery(companyId,page,pageSize));
            return Ok(result);
        }
    }
}
