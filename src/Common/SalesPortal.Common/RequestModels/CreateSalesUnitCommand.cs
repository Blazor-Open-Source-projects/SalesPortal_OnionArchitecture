using MediatR;

namespace SalesPortal.Common.RequestModels;

public class CreateSalesUnitCommand : IRequest<Guid>
{
    public int Quantity { get; set; }
    public int Package { get; set; }
    public double Price { get; set; }
    public Guid EnvanterId { get; set; }
}
