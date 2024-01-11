using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Common.Infrastructure.Extensions;
using SalesPortal.Common.Models.Page;
using SalesPortal.Common.Models.Queries;

namespace SalesPortal.Api.Application.Features.Queries.GetMainPageProducts;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, PagedViewModel<GetProductViewModel>>
{
    private readonly IProductRepository productRepository;
    private readonly IMapper mapper;

    public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        this.productRepository = productRepository;
        this.mapper = mapper;
    }

    public Task<PagedViewModel<GetProductViewModel>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var query = productRepository.AsQueryable();

        query = query
            .Include(i => i.Category)
            .Include(i => i.SalesUnits)
            .ThenInclude(i=>i.Envanter)
            .Where(p => p.SalesUnits.Any(su => su.Envanter.CompanyId == request.CompanyId));


        var list = query.Select(i => new GetProductViewModel()
        {
                Id = i.Id,
                CategoryName = i.Category.Name,
                Description = i.Description,
                Name = i.Name,
                SalesUnits = mapper.Map<List<GetSalesUnitViewModel>>(i.SalesUnits),
                Price = i.Price,
        });

        var products = list.GetPagedAsync(request.Page, request.PageSize);

        return products;
    }
}
