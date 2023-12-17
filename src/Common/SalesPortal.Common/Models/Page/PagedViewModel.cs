namespace SalesPortal.Common.Models.Page;

public class PagedViewModel<T> where T : class
{
    public PagedViewModel(): this(new List<T>(), new Page())
    {
        
    }

    public PagedViewModel(List<T> results, Page pageInfo)
    {
        Results = results;
        PageInfo = pageInfo;
    }

    public List<T> Results { get; set; }
    public Page PageInfo { get; set; }
}
