using MediatR;
using SalesPortal.Api.Application.Interfaces.Repositories;

namespace SalesPortal.Api.Application.Features.Commands.SalesUnit.Delete;

public class DeleteSalesUnitCommandHandler : IRequestHandler<DeleteSalesUnitCommand, bool>
{
    private readonly ISalesUnitRepository salesUnitRepository;

    public DeleteSalesUnitCommandHandler(ISalesUnitRepository salesUnitRepository)
    {
        this.salesUnitRepository = salesUnitRepository;
    }

    public async Task<bool> Handle(DeleteSalesUnitCommand request, CancellationToken cancellationToken)
    {
        var result = await salesUnitRepository.DeleteAsync(request.SalesUnitId);
        
        if(result>0)
            return true;
        return false;
    }
}
