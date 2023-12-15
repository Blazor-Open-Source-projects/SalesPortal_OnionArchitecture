using MediatR;
using SalesPortal.Api.Domain.Models;

namespace SalesPortal.Api.Application.Features.Commands.Product.Delete;

public class DeleteProductCommand : IRequest<bool>
{
    public DeleteProductCommand(Guid? companyId, Guid productId)
    {
        CompanyId = companyId;
        ProductId = productId;
    }

    public Guid? CompanyId { get; set; }
    public Guid ProductId { get; set; }
}
