using WebStore_Study.Domain.Entities;
using WebStore_Study.Domain.Entities.Base.Interfaces;

namespace WebStore_Study.Domain.ViewModels
{
    public class ProductViewModel : INamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public Brand Brand { get; set; }
    }
}
