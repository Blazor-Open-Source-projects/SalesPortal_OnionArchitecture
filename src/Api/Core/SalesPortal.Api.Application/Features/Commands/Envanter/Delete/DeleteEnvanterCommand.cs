using MediatR;

namespace SalesPortal.Api.Application.Features.Commands.Envanter.Delete;
public class DeleteEnvanterCommand : IRequest<bool>
{
    public DeleteEnvanterCommand(Guid envanterId, Guid companyId)
    {
        EnvanterId = envanterId;
        CompanyId = companyId;
    }

    public Guid EnvanterId { get; set; }
    public Guid CompanyId { get; set; }
}

