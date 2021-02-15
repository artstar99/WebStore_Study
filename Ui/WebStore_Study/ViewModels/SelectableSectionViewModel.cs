using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Domain.ViewModels;

namespace WebStore_Study.ViewModels
{
    public class SelectableSectionViewModel
    {
        public IEnumerable<SectionViewModel> Sections { get; set; }
        public int? SectionId { get; set; }
        public int? ParentSectionId { get; set; }
    }
}
