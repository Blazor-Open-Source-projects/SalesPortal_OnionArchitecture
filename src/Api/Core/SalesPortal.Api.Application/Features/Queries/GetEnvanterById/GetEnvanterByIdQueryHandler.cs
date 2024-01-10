using AutoMapper;
using MediatR;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Api.Domain.Models;
using SalesPortal.Common.Infrastructure.Exceptions;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.Api.Application.Features.Queries.GetEnvanterById;

public class GetEnvanterByIdQueryHandler : IRequestHandler<GetEnvanterByIdQuery, CreateEnvanterCommand>
{
    private readonly IMapper mapper;
    private readonly IEnvaterRepository envaterRepository;

    public GetEnvanterByIdQueryHandler(IMapper mapper, IEnvaterRepository envaterRepository)
    {
        this.mapper = mapper;
        this.envaterRepository = envaterRepository;
    }

    public async Task<CreateEnvanterCommand> Handle(GetEnvanterByIdQuery request, CancellationToken cancellationToken)
    {
        var dbData = await envaterRepository.GetByIdAsync(request.EnvanterId);

        if (dbData is null)
            throw new DatabaseValidationException("Envanter does not exists");
        if(request.CompanyId != dbData.CompanyId)
            throw new DatabaseValidationException("You are not allowed to see this item");
        
        return mapper.Map<CreateEnvanterCommand>(dbData);  
    }
}
