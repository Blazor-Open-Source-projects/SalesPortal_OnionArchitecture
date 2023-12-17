using MediatR;

namespace SalesPortal.Common.Models.RequestModels;

public class UpdateEnvanterCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int StockQuantity { get; set; }
    public string ENVCode { get; set; }
    public Guid CompanyId { get; set; }
    public Guid BrandId { get; set; }
}
