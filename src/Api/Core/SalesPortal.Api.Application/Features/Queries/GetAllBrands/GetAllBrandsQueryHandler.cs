using AutoMapper;
using MediatR;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Common.Models.Queries;

namespace SalesPortal.Api.Application.Features.Queries.GetAllBrands;

public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, List<GetBrandsViewModel>>
{
    private readonly IBrandRepository brandRepository;
    private readonly IMapper mapper;

    public GetAllBrandsQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        this.brandRepository = brandRepository;
        this.mapper = mapper;
    }

    public async Task<List<GetBrandsViewModel>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await brandRepository.GetAll(null);

        var brandData = mapper.Map<List<GetBrandsViewModel>>(brands); 

        return brandData;
    }
}
