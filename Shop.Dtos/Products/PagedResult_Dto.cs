using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Dtos.Products
{
    // create Pagination Response Wrapper 
    public class PagedResult_Dto<T>
    {
        // Properties 
        public IEnumerable<T>? Items { get; set; }
        public int TotalCount { get; set; }
    }
}
