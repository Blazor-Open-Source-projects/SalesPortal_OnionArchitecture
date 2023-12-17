using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesPortal.Api.Application.Features.Commands.SalesUnit.Delete;
using SalesPortal.Common.Models.RequestModels;

namespace BlazorSozluk.Api.Persistence.WebApi.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SalesUnitController : ControllerBase
    {

        private readonly IMediator mediator;

        public SalesUnitController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSalesUnitCommand command)
        {
            var result =  await mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid companyId, Guid salesUnitId)
        {
            var result = await mediator.Send(new DeleteSalesUnitCommand(salesUnitId, companyId));

            return Ok(result);
        }
    }
}
