using System;
using System.Collections.Generic;

namespace WebStore_Study.Domain.ViewModels
{
    public class CatalogViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public int? SectionId { get; set; }
        public int? BrandId { get; set; }
        public PageViewModel PageViewModel { get; init; }
    }
    public class PageViewModel
    {
        public int Page { get; init; }
        public int PageSize { get; init; }
        public int TotalItems { get; init; }
        public int TotalPages => PageSize == 0 ? 0 : (int)Math.Ceiling((double)TotalItems / PageSize);

    }
}
