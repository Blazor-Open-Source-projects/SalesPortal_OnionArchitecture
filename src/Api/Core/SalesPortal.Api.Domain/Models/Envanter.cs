namespace SalesPortal.Api.Domain.Models;

public class Envanter : BaseEntity
{
    public string Name { get; set; }
    public int StockQuantity { get; set; }
    public string ENVCode { get; set; }
    public Guid CompanyId { get; set; }
    public Guid BrandId { get; set; }

    public virtual ICollection<SalesUnit> SalesUnits { get; set; }
    public virtual Company Company { get; set; }
    public virtual Brand Brand { get; set; }
}