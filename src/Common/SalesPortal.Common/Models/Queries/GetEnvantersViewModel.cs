namespace SalesPortal.Common.Models.Queries;

public class GetEnvantersViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int StockQuantity { get; set; }
    public string ENVCode { get; set; }
    public Guid brandId { get; set; }
    public string BrandName {  get; set; }  
}
