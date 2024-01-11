using MediatR;

namespace SalesPortal.Common.Models.RequestModels;

public class UpdateProductCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public Guid CategoryId { get; set; }
    public Guid CompanyId { get; set; }
    public virtual ICollection<CreateSalesUnitCommand> SalesUnits { get; set; }
}
