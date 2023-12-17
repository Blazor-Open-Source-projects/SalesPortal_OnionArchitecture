namespace SalesPortal.Common.Models.Page;

public class BasePaged
{
    public BasePaged(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
    }

    public int Page { get; set; }
    public int PageSize { get; set; }
}
