using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Common.Infrastructure.Extensions;
using SalesPortal.Common.Models.Page;
using SalesPortal.Common.Models.Queries;

namespace SalesPortal.Api.Application.Features.Queries.GetEnvantersByBrand;

public class GetEnvantersByBrandQueryHandler : IRequestHandler<GetEnvantersByBrandQuery, PagedViewModel<GetEnvantersViewModel>>
{
    private readonly IEnvaterRepository envaterRepository;

    public GetEnvantersByBrandQueryHandler(IEnvaterRepository envaterRepository)
    {
        this.envaterRepository = envaterRepository;
    }

    public async Task<PagedViewModel<GetEnvantersViewModel>> Handle(GetEnvantersByBrandQuery request, CancellationToken cancellationToken)
    {
        var query = envaterRepository.AsQueryable();

        query = query.Include(i => i.Brand).Where(i => i.CompanyId == request.CompanyId &&  i.BrandId == request.BrandId);

        var list = query.Select(i => new GetEnvantersViewModel()
        {
           Id = i.Id,
           BrandName = i.Brand.Name,
           brandId = request.BrandId,
           ENVCode = i.ENVCode,
           Name = i.Name,
           StockQuantity = i.StockQuantity
        });

        var envanters = await list.GetPagedAsync(request.Page,request.PageSize);

        return envanters;
    }
}
