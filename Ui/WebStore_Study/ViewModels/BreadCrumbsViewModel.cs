using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Domain.Entities;

namespace WebStore_Study.ViewModels
{
    public class BreadCrumbsViewModel
    {
        public Section Section { get; set; }
        public Brand Brand { get; set; }
        public Product Product { get; set; }
    }
}
