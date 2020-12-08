using System;
using System.Collections.Generic;
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
        public DateTime CreationTime { get; set; }
        public List<string> Tags { get; set; }
    }
}
