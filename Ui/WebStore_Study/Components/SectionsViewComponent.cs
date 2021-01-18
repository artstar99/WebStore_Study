using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Infrastructure.Interfaces;
using WebStore_Study.ViewModels;

namespace WebStore_Study.Components
{   
    [ViewComponent]
    public class SectionsViewComponent:ViewComponent
    {
        private readonly IProductData productData;
        public SectionsViewComponent(IProductData productData)
        {
            this.productData = productData;
        }
        public IViewComponentResult Invoke()
        {
            var sections = productData.GetSections().ToList();

            var parentSections = sections.Where(s => s.ParentId == null);

            var parentSectionViewModels = parentSections
                .Select(s => new SectionViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Order = s.Order,
                })
                .OrderBy(s=>s.Order)
                .ToList();

            foreach (var parentSection in parentSectionViewModels)
            {
                var childs = sections
                    .Where(s => s.ParentId == parentSection.Id)
                    .OrderBy(s=>s.Order)
                    .ToList();

                foreach (var childSection in childs)
                {
                    parentSection.ChildSection.Add(new SectionViewModel() 
                    {
                        Id=childSection.Id,
                        Name=childSection.Name,
                        Order=childSection.Order,
                        ParentSection=parentSection,
                    });
                }

                //parentSection.ChildSection.Sort((x, y) => x.Order.CompareTo(y.Order));
            }


            return View(parentSectionViewModels);
        }
    }
}
