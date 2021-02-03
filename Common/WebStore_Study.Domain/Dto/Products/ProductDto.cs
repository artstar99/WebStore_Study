using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore_Study.Domain.Dto.Products
{
    /// <summary>
    /// Бренд
    /// </summary>
    public record BrandDto(int Id, string Name, int Order, int ProductsCount);

    /// <summary>
    /// Секция
    /// </summary>
    public record SectionDto(int Id, string Name, int Order, int? ParentId, int? ProductsCount);

    /// <summary>
    /// Товар
    /// </summary>
    public record ProductDto(int Id, string Name, int Order, decimal Price, string ImageUrl, BrandDto Brand,
        SectionDto Section);
}
