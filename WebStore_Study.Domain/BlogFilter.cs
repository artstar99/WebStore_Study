using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore_Study.Domain
{
    public class BlogFilter
    {
        public int? CurrentPage { get; set; }

        public int BlogsPerPage { get; set; }
    }
}
