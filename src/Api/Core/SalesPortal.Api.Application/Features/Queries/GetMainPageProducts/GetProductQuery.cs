using MediatR;
using SalesPortal.Common.Models.Page;
using SalesPortal.Common.Models.Queries;

namespace SalesPortal.Api.Application.Features.Queries.GetMainPageProducts;

public class GetProductQuery : BasePaged, IRequest<PagedViewModel<GetProductViewModel>>
{
    public GetProductQuery(int page, int pageSize, Guid companyId) : base(page, pageSize)
    {
        CompanyId = companyId;
    }

    public Guid CompanyId { get; set; }
}
