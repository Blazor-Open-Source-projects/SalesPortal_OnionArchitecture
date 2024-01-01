using AutoMapper;
using MediatR;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Common.Models.Queries;

namespace SalesPortal.Api.Application.Features.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<GetCategoryViewModel>>
{
    private readonly ICategoryRepository categoryReposittory;
    private readonly IMapper mapper;

    public GetAllCategoriesQueryHandler(ICategoryRepository categoryReposittory,
                IMapper mapper)
    {
        this.categoryReposittory = categoryReposittory;
        this.mapper = mapper;
    }

    public async Task<List<GetCategoryViewModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories =await categoryReposittory.GetAll(null);

        var data = mapper.Map<List<GetCategoryViewModel>>(categories);

        return  data;
    }
}
