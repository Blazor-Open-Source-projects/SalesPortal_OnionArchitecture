using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesPortal.Api.Application.Features.Commands.Envanter.Delete;
using SalesPortal.Api.Application.Features.Queries.GetEnvanterById;
using SalesPortal.Api.Application.Features.Queries.GetEnvanters;
using SalesPortal.Api.Application.Features.Queries.GetEnvantersByBrand;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.Api.Persistence.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EnvanterController : BaseController
    {
        private readonly IMediator mediator;
        public EnvanterController(IMediator mediator)
        {
            this.mediator = mediator;   
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEnvanterCommand command)
        {
            command.CompanyId = CompanyId.Value; 
            var result =await mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("update/{companyId}")]
        public async Task<IActionResult> Update(Guid companyId,UpdateEnvanterCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid envanterId, Guid companyId)
        {
            companyId = CompanyId.Value;

            var result = await mediator.Send(new DeleteEnvanterCommand(envanterId,companyId));

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetEnvanters(int page, int pageSize,Guid companyId)
        {
            if (companyId == Guid.Empty)
                companyId = CompanyId.Value;
            var result = await mediator.Send(new GetEnvanterQuery(companyId,page,pageSize));
            return Ok(result);
        }


        [HttpGet("bybrandid")]
        public async Task<IActionResult> GetEnvantersByBrand(int page, int pageSize, Guid companyId, Guid BrandId)
        {
            if (companyId == Guid.Empty)
                companyId = CompanyId.Value;

            var result = await mediator.Send(new GetEnvantersByBrandQuery(page,pageSize,companyId,BrandId));
            return Ok(result);
        }

        [HttpGet("{envanterId}")]
        public async Task<IActionResult> GetEnvanterByEnvanterId(Guid envanterId, Guid companyId)
        {
            companyId = CompanyId.Value;

            var res = await mediator.Send(new GetEnvanterByIdQuery(envanterId,companyId));

            return Ok(res);
        }
    }
}
