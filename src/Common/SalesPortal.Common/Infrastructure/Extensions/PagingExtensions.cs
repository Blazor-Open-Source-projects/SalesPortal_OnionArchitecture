﻿using SalesPortal.Common.Models.Page;
using Microsoft.EntityFrameworkCore;

namespace SalesPortal.Common.Infrastructure.Extensions;

public static class PagingExtensions
{
    public static async Task<PagedViewModel<T>>  GetPagedAsync<T>(this IQueryable<T> query,
                                                            int currentPage,
                                                            int pageSize) where T : class
    {
        var count = await query.CountAsync();

        Page paging = new(currentPage, pageSize, count);

        var data = await query.Skip(paging.Skip).Take(paging.PageSize).AsNoTracking().ToListAsync();

        var result = new PagedViewModel<T>(data,paging); 

        return result;  

    }
}