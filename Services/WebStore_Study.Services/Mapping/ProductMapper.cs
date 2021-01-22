using System.Collections.Generic;
using System.Linq;
using WebStore_Study.Domain.Dto.Products;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Domain.ViewModels;

namespace WebStore_Study.Services.Mapping
{
    public static class ProductMapper
    {
        public static ProductViewModel ToView(this Product p) => new ProductViewModel()
        {
            Id = p.Id,
            Order = p.Order,
            Name = p.Name,
            ImageUrl = p.ImageUrl,
            Price = p.Price,
            Brand = p.Brand
        };

        public static IEnumerable<ProductViewModel> ToView(this IEnumerable<Product> p) => p.Select(ToView);


        public static ProductDto ToDto(this Product product) => product is null
            ? null
            : new ProductDto (
                product.Id,
                product.Name,
                product.Order,
                product.Price, 
                product.ImageUrl,
                product.Brand.ToDto(),
                product.Section.ToDto());

        public static Product FromDto(this ProductDto productDto) => productDto is null
            ? null
            : new Product()
            {
                Name = productDto.Name,
                Id = productDto.Id,
                BrandId = productDto.Brand?.Id,
                Brand = productDto.Brand.FromDto(),
                SectionId = productDto.Section.Id,
                ImageUrl = productDto.ImageUrl,
                Order = productDto.Order,
                Price = productDto.Price,
                Section = productDto.Section.FromDto()
            };

        public static IEnumerable<ProductDto> ToDto(this IEnumerable<Product> products) => products.Select(ToDto);
        public static IEnumerable<Product> FromDto(this IEnumerable<ProductDto> productsDto) => productsDto.Select(FromDto);
    }
}
