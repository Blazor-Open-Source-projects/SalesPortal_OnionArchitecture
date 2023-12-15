using MediatR;

namespace SalesPortal.Api.Application.Features.Commands.SalesUnit.Delete;

public class DeleteSalesUnitCommand : IRequest<bool>
{
    public DeleteSalesUnitCommand(Guid salesUnitId, Guid companyId)
    {
        SalesUnitId = salesUnitId;
        CompanyId = companyId;
    }

    public Guid SalesUnitId { get; set; }
    public Guid CompanyId { get; set; }
}
