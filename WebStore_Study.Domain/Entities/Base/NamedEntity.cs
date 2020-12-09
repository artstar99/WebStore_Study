using System.ComponentModel.DataAnnotations;
using WebStore_Study.Domain.Entities.Base.Interfaces;

namespace WebStore_Study.Domain.Entities.Base
{
    public abstract class NamedEntity : Entity, INamedEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
