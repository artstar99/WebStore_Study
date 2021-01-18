using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore_Study.Domain.Entities.Base;
using WebStore_Study.Domain.Entities.Base.Interfaces;

namespace WebStore_Study.Domain.Entities
{
    public class Section : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public Section Parent { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
