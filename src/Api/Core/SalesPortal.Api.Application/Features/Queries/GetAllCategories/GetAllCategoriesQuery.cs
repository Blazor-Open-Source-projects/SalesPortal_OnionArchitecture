using MediatR;
using SalesPortal.Common.Models.Queries;

namespace SalesPortal.Api.Application.Features.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<List<GetCategoryViewModel>>
{
}
