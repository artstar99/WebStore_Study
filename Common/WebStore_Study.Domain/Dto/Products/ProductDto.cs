using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore_Study.Domain.Dto.Products
{
    public record BrandDto(int Id, string Name, int Order);

    public record SectionDto(int Id, string Name, int Order, int? ParentId);

    public record ProductDto(
        int Id, 
        string Name,
        int Order, 
        decimal Price, 
        string ImageUrl, 
        BrandDto Brand,
        SectionDto Section);
}
