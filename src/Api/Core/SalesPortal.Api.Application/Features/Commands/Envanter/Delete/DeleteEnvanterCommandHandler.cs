using MediatR;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Common.Infrastructure.Exceptions;

namespace SalesPortal.Api.Application.Features.Commands.Envanter.Delete;

public class DeleteEnvanterCommandHandler : IRequestHandler<DeleteEnvanterCommand, bool>
{
    private readonly IEnvaterRepository envaterRepository;

    public DeleteEnvanterCommandHandler(IEnvaterRepository envaterRepository)
    {
        this.envaterRepository = envaterRepository;
    }

    public async Task<bool> Handle(DeleteEnvanterCommand request, CancellationToken cancellationToken)
    {
        var envanterDb = await envaterRepository.GetByIdAsync(request.EnvanterId);

        if (envanterDb == null)
            throw new DatabaseValidationException("Envanter does not exist");
        if (request.CompanyId != envanterDb.CompanyId)
            throw new DatabaseValidationException("You are not allowed to delete this item");

        var result = await envaterRepository.DeleteAsync(envanterDb);

        if (result > 0)
            return true;

        return false;
    }
}
