using MediatR;
using SalesPortal.Common.Models.Page;
using SalesPortal.Common.Models.Queries;

namespace SalesPortal.Api.Application.Features.Queries.GetEnvanters;


public class GetEnvanterQuery : BasePaged, IRequest<PagedViewModel<GetEnvantersViewModel>>
{
    public GetEnvanterQuery(Guid companyId, int page, int pageSize) : base(page, pageSize)
    {
        CompanyId = companyId;  
    }
    public Guid CompanyId { get; set; }
}
