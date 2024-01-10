﻿namespace SalesPortal.Common.Models.Queries;

public  class GetProductViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string  CategoryName { get; set; }
    public List<GetSalesUnitViewModel> SalesUnits { get; set; }
}
