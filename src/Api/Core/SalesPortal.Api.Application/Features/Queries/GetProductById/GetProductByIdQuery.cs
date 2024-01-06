using MediatR;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.Api.Application.Features.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<CreateProductCommand>
{
    public Guid ProductId { get; set; }
    public Guid CompanyId { get; set; }

    public GetProductByIdQuery(Guid productId, Guid companyId)
    {
        ProductId = productId;
        CompanyId = companyId;
    }
}
