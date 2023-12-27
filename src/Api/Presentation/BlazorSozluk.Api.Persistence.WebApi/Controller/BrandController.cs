using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesPortal.Api.Application.Features.Queries.GetAllBrands;

namespace BlazorSozluk.Api.Persistence.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator mediator;

        public BrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await mediator.Send(new GetAllBrandsQuery());
            return Ok(result);  
        }
    }
}
