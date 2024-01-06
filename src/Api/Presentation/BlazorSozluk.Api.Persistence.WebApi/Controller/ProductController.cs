using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesPortal.Api.Application.Features.Commands.Product.Delete;
using SalesPortal.Api.Application.Features.Queries.GetMainPageProducts;
using SalesPortal.Api.Application.Features.Queries.GetProductById;
using SalesPortal.Common.Models.Queries;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.Api.Persistence.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand comamnd)
        {
            var result = await mediator.Send(comamnd);

            return Ok(result);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid? CompanyId, Guid ProductId)
        {
            var result = await mediator.Send(new DeleteProductCommand(CompanyId, ProductId));

            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProductsByCompanyyId(int page, int pageSize, Guid companyId)
        {
            if (companyId == Guid.Empty)
                companyId = CompanyId.Value;

            var result = await mediator.Send(new GetProductQuery(page, pageSize, companyId));

            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductByI(Guid productId, Guid companyId)
        {
            companyId = CompanyId.Value;
            var res = await mediator.Send(new GetProductByIdQuery(productId,companyId));

            return Ok(res);
        }
    }
}
