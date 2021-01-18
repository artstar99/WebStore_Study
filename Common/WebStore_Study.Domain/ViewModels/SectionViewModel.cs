using System.Collections.Generic;
using WebStore_Study.Domain.Entities.Base.Interfaces;

namespace WebStore_Study.Domain.ViewModels
{
    public class SectionViewModel : INamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public List<SectionViewModel> ChildSection { get; set; } = new List<SectionViewModel>();
        
        public SectionViewModel ParentSection { get; set; }
    }
}
