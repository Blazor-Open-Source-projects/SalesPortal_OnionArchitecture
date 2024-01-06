using MediatR;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.Api.Application.Features.Queries.GetEnvanterById;

public class GetEnvanterByIdQuery : IRequest<CreateEnvanterCommand>
{
    public Guid EnvanterId { get; set; }
    public Guid CompanyId { get; set; }

    public GetEnvanterByIdQuery(Guid envanterId, Guid companyId)
    {
        EnvanterId = envanterId;
        CompanyId = companyId;
    }
}
