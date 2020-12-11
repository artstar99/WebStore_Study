﻿using System.Collections.Generic;

namespace WebStore_Study.ViewModels
{
    public class CatalogViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public int? SectionId { get; set; }
        public int? BrandId { get; set; }
    }
}
