using AutoMapper;
using MediatR;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Api.Domain.Models;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.Api.Application.Features.Commands.SalesUnit.Create;

public class CreateSalesUnitCommandHandler : IRequestHandler<CreateSalesUnitCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly ISalesUnitRepository salesUnitRepository;

    public CreateSalesUnitCommandHandler(IMapper mapper, ISalesUnitRepository salesUnitRepository)
    {
        this.mapper = mapper;
        this.salesUnitRepository = salesUnitRepository;
    }

    public async Task<Guid> Handle(CreateSalesUnitCommand request, CancellationToken cancellationToken)
    {
        var dbEntry = mapper.Map<Domain.Models.SalesUnit>(request);
        await salesUnitRepository.AddAsync(dbEntry);
        
        return dbEntry.Id;
    }
}
