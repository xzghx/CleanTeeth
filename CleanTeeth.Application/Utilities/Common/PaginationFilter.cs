using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Utilities.Common;

public class PaginationFilter
{
    const int maxPageSize = 100;
    public int Page { get; set; } = 1;
    private int _pageSize = 100;
    public int PageSize
    {
        get { return _pageSize; }
        set
        {
            _pageSize = value > maxPageSize ? maxPageSize : value;
        }
    }
    public PaginationFilter()
    {
        Page = 1;
        PageSize = maxPageSize;
    }
    public PaginationFilter(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
    }
}
