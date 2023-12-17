namespace SalesPortal.Common.Models.Queries;

public  class GetProductViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string  CategoryName { get; set; }
    public List<GetEnvantersViewModel> GetEnvanters { get; set; }
}
