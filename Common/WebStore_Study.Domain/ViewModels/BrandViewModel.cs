using WebStore_Study.Domain.Entities.Base.Interfaces;

namespace WebStore_Study.Domain.ViewModels
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductsCount { get; set; }
    }
}
