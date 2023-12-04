namespace SalesPortal.Api.Domain.Models
{
    public class SalesUnit : BaseEntity
    {
        public int Quantity { get; set; }
        public int Package { get; set; }
        public double Price { get; set; }
        public Guid EnvanterId { get; set; }


        public virtual Envanter Envanter { get; set; }
        public virtual ICollection<SalesProduct> SalesProducts { get; set; }
    }
}
