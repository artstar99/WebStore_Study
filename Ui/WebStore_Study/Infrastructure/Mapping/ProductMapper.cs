using System.Collections.Generic;
using System.Linq;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Domain.ViewModels;

namespace WebStore_Study.Infrastructure.Mapping
{
    public static class ProductMapper
    {
        public static ProductViewModel ToView(this Product p) => new()
        {
            Id = p.Id,
            Order = p.Order,
            Name = p.Name,
            ImageUrl = p.ImageUrl,
            Price = p.Price,
            Brand = p.Brand
        };

        public static IEnumerable<ProductViewModel> ToView(this IEnumerable<Product> p) => p.Select(ToView);

    }
}
