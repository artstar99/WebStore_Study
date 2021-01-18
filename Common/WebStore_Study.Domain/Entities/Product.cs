using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore_Study.Domain.Entities.Base;
using WebStore_Study.Domain.Entities.Base.Interfaces;

namespace WebStore_Study.Domain.Entities
{
    public  class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int SectionId { get; set; }
        public int? BrandId { get; set; }
        public string ImageUrl { get; set; }
        
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(SectionId))]
        public Section Section { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }
    }
}
