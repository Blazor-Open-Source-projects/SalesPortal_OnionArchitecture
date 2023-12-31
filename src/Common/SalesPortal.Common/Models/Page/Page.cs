﻿namespace SalesPortal.Common.Models.Page;

public class Page 
{
    public Page() : this(0)
    {
        
    }

    public Page(int totalRowCount) : this(1, 10,totalRowCount)
    {
    }

    public Page(int pageSize, int totalRowCount) : this(1,pageSize,totalRowCount)
    {
        PageSize = pageSize;
        TotalRowCount = totalRowCount;
    }

    public Page(int currentPage, int pageSize, int totalRowCount)
    {
        if (currentPage < 1)
            throw new ArgumentException("Invalid Page Number");

        if (pageSize < 1)
            throw new ArgumentException("Invalid Page Size");

        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalRowCount = totalRowCount;
    }

    public int CurrentPage { get; set; }
    public int PageSize { get; set; }

    public int TotalRowCount { get; set; }
    public int TotalPageCount => (int)Math.Ceiling((double)TotalRowCount / PageSize);
    public int Skip => (CurrentPage -1 ) * PageSize;

}
