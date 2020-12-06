using WebStore_Study.Domain.Entities.Base.Interfaces;

namespace WebStore_Study.Domain.Entities.Base
{
    public abstract class NamedEntity : Entity, INamedEntity
    {
        public string Name { get; set; }
    }
}
