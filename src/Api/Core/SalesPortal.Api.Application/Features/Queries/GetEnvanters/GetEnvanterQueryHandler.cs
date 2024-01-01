using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Common.Infrastructure.Extensions;
using SalesPortal.Common.Models.Page;
using SalesPortal.Common.Models.Queries;

namespace SalesPortal.Api.Application.Features.Queries.GetEnvanters;

public class GetEnvanterQueryHandler : IRequestHandler<GetEnvanterQuery, PagedViewModel<GetEnvantersViewModel>>
{
    private readonly IEnvaterRepository envaterRepository;
    private readonly IMapper mapper;

    public GetEnvanterQueryHandler(IEnvaterRepository envaterRepository, IMapper mapper)
    {
        this.envaterRepository = envaterRepository;
        this.mapper = mapper;
    }

    public async Task<PagedViewModel<GetEnvantersViewModel>> Handle(GetEnvanterQuery request, CancellationToken cancellationToken)
    {
        var query = envaterRepository.AsQueryable();

        query = query.Include(i => i.Brand).Where(e => e.CompanyId == request.CompanyId);

        var list = query.Select(i => new GetEnvantersViewModel
        {
            BrandName = i.Brand.Name,
            ENVCode = i.ENVCode,
            Name = i.Name,
            Id = i.Id,
            StockQuantity = i.StockQuantity,
            brandId = i.BrandId
        });
        var result = await list.GetPagedAsync(request.Page, request.PageSize);


        return result;
    }
}
