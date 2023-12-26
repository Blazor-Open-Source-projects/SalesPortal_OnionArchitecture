using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesPortal.Api.Application.Features.Commands.Product.Delete;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.Api.Persistence.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand comamnd)
        {
            var result =await mediator.Send(comamnd);

            return Ok(result);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid? CompanyId, Guid ProductId)
        {
            var result = await mediator.Send(new DeleteProductCommand(CompanyId, ProductId));

            return Ok(result);
        }
    }
}
