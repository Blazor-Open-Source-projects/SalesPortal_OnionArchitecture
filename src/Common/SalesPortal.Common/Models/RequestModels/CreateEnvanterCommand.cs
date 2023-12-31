using MediatR;
using System.ComponentModel.DataAnnotations;

namespace SalesPortal.Common.Models.RequestModels;

public class CreateEnvanterCommand : IRequest<Guid>
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; }
    public int StockQuantity { get; set; }
    [Required]
    [MinLength(2)]
    public string ENVCode { get; set; }
    public Guid CompanyId { get; set; }
    [Required]
    public Guid BrandId { get; set; }
}
