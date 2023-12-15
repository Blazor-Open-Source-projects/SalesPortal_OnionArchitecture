using AutoMapper;
using MediatR;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.Api.Application.Features.Commands.Envanter.Create;
public class CreateEnvanterCommandHandler : IRequestHandler<CreateEnvanterCommand, Guid>
{
    private readonly IEnvaterRepository envaterRepository;
    private readonly IMapper mapper;

    public CreateEnvanterCommandHandler(IEnvaterRepository envaterRepository, IMapper mapper)
    {
        this.envaterRepository = envaterRepository;
        this.mapper = mapper;
    }

    public async Task<Guid> Handle(CreateEnvanterCommand request, CancellationToken cancellationToken)
    {

        var dbEnvanter = mapper.Map<Domain.Models.Envanter>(request);
        await envaterRepository.AddAsync(dbEnvanter);

        return dbEnvanter.Id;
    }
}
