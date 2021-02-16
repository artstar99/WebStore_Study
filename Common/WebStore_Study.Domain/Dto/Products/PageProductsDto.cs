using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore_Study.Domain.Dto.Products
{
    public class PageProductsDto
    {
        /// <summary>
        /// Collection of products
        /// </summary>
        public IEnumerable<ProductDto> Products { get; init; }

        /// <summary>
        /// Total products quantity in collection
        /// </summary>
        public int TotalCount { get; init; }
    }
}
