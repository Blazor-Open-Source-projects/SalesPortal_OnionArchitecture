using MediatR;

namespace SalesPortal.Common.RequestModels;

public class CreateProductCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
}
