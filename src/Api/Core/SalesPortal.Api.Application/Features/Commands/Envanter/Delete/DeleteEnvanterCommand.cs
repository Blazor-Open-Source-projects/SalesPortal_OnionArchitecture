using MediatR;

namespace SalesPortal.Api.Application.Features.Commands.Envanter.Delete;
public class DeleteEnvanterCommand : IRequest<bool>
{
    public DeleteEnvanterCommand(Guid userId, Guid companyId)
    {
        UserId = userId;
        CompanyId = companyId;
    }

    public Guid UserId { get; set; }
    public Guid CompanyId { get; set; }
}

