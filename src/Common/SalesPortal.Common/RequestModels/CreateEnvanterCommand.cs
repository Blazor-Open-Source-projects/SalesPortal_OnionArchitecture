using MediatR;

namespace SalesPortal.Common.Models.RequestModels;

public class CreateEnvanterCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public int StockQuantity { get; set; }
    public string ENVCode { get; set; }
    public Guid CompanyId { get; set; }

}
