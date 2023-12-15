using MediatR;
using SalesPortal.Api.Application.Interfaces.Repositories;

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
        var result = await envaterRepository.DeleteAsync(request.UserId);

        if (result > 0)
            return true;

        return false;
    }
}
