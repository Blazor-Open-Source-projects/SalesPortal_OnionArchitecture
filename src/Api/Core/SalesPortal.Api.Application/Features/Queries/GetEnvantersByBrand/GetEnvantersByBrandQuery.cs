using MediatR;
using SalesPortal.Common.Models.Page;
using SalesPortal.Common.Models.Queries;

namespace SalesPortal.Api.Application.Features.Queries.GetEnvantersByBrand;

public class GetEnvantersByBrandQuery : BasePaged, IRequest<PagedViewModel<GetEnvantersViewModel>>
{
    public Guid CompanyId { get; set; }
    public Guid BrandId { get; set; }
    public GetEnvantersByBrandQuery(int page, int pageSize, Guid companyId, Guid brandId) : base(page, pageSize)
    {
        CompanyId = companyId;
        BrandId = brandId;
    }
}
