using AutoMapper;
using MediatR;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Api.Domain.Models;
using SalesPortal.Common.Infrastructure.Exceptions;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.Api.Application.Features.Commands.Envanter.Update;

public class UpdateEnvanterCommandHandler : IRequestHandler<UpdateEnvanterCommand, bool>
{
    private readonly IEnvaterRepository envaterRepository;
    private readonly IMapper mapper;

    public UpdateEnvanterCommandHandler(IEnvaterRepository envaterRepository, IMapper mapper)
    {
        this.envaterRepository = envaterRepository;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(UpdateEnvanterCommand request, CancellationToken cancellationToken)
    {
        var envanter = await envaterRepository.GetByIdAsync(request.Id);
        
        if (envanter is null)
            throw new DatabaseValidationException("Envanter not Found");

        if (request.CompanyId != envanter.CompanyId)
            throw new DatabaseValidationException("You can not update this Envanter");

        envanter.CreatedDate = DateTime.UtcNow;
        envanter.ENVCode = request.ENVCode;
        envanter.BrandId = request.BrandId;
        envanter.StockQuantity = request.StockQuantity;
        envanter.Name = request.Name;

        await envaterRepository.UpdateAsync(envanter);

        return true;
    }
}
