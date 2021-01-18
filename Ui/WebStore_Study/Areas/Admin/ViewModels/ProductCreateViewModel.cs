using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebStore_Study.Domain.Entities;

namespace WebStore_Study.Areas.Admin.ViewModels
{
    public class ProductCreateViewModel
    {
        public Product Product { get; set; }
              
        public IEnumerable<Brand> Brands { get; set; }

        public IEnumerable<Section> Sections { get; set; }
        
        public IFormFile Image { get; set; }
    }

}
