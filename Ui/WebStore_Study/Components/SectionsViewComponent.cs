using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebStore_Study.Domain.ViewModels;
using WebStore_Study.Interfaces.Services;
using WebStore_Study.ViewModels;

namespace WebStore_Study.Components
{
    [ViewComponent]
    public class SectionsViewComponent : ViewComponent
    {
        private readonly IProductData productData;
        public SectionsViewComponent(IProductData productData)
        {
            this.productData = productData;
        }
        public IViewComponentResult Invoke(string SectionId)
        {

            var sectionId = int.TryParse(SectionId, out var id) ? id : (int?)null;

            var sections = GetSections(sectionId, out var parentSectionId);

            return View(new SelectableSectionViewModel()
            {
                Sections = sections,
                SectionId = sectionId,
                ParentSectionId = parentSectionId,

            });
        }

        private IEnumerable<SectionViewModel> GetSections(int? SectionId, out int? parentSectionId)
        {
            parentSectionId = null;



            var sections = productData.GetSections().ToList();

            var parentSections = sections.Where(s => s.ParentId == null);

            var parentSectionViewModels = parentSections
                .Select(s => new SectionViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Order = s.Order,
                })
                .OrderBy(s => s.Order)
                .ToList();

            foreach (var parentSection in parentSectionViewModels)
            {
                var childs = sections
                    .Where(s => s.ParentId == parentSection.Id)
                    .OrderBy(s => s.Order)
                    .ToList();

                foreach (var childSection in childs)
                {
                    if (childSection.Id == SectionId)
                        parentSectionId = childSection.ParentId;
                    parentSection.ChildSection.Add(new SectionViewModel()
                    {
                        Id = childSection.Id,
                        Name = childSection.Name,
                        Order = childSection.Order,
                        ParentSection = parentSection,
                    });
                }
            }

            return parentSectionViewModels;
        }
    }
}
