namespace SalesPortal.Api.Domain.Models;

public class Brand : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<SalesProduct> Products {get; set; }
}
