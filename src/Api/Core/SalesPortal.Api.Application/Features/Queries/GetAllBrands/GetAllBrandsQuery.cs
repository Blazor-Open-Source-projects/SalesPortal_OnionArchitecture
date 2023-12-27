using MediatR;
using SalesPortal.Common.Models.Queries;

namespace SalesPortal.Api.Application.Features.Queries.GetAllBrands;

public class GetAllBrandsQuery : IRequest<List<GetBrandsViewModel>>
{
    public int Count { get; set; }
}
