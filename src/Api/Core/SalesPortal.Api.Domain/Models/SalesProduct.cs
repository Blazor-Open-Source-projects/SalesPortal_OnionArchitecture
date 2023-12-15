namespace SalesPortal.Api.Domain.Models;

public class SalesProduct : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }

    public virtual ICollection<SalesUnit> SalesUnits { get; set; }
    public virtual Category Category { get; set; }
    public virtual Brand Brand { get; set; }

}
