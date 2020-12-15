using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore_Study.Domain.Entities.Base;
using WebStore_Study.Domain.Entities.Base.Interfaces;

namespace WebStore_Study.Domain.Entities
{
    public class Blog : NamedEntity
    {
        public string ImageName { get; set; }
        public string MainText { get; set; }
        public string Author { get; set; }
        
        [Column(TypeName ="datetime")]
        public DateTime CreationTime { get; set; }
        
        [NotMapped]
        public List<string> Tags { get; set; }
    }
}
