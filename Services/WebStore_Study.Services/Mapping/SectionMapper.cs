using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore_Study.Domain.Dto.Products;
using WebStore_Study.Domain.Entities;

namespace WebStore_Study.Services.Mapping
{
    public static class SectionMapper
    {
        public static SectionDto ToDto(this Section section) =>
            section is null
                ? null
                : new SectionDto(section.Id, section.Name, section.Order, section.ParentId, section.Products?.Count);

        public static Section FromDto(this SectionDto sectionDto) => sectionDto is null
            ? null
            : new Section()
            {
                Id= sectionDto.Id,
                Name = sectionDto.Name,
                Order = sectionDto.Order,
                ParentId = sectionDto.ParentId,
            };

        public static IEnumerable<SectionDto> ToDto(this IEnumerable<Section> sections) => sections.Select(ToDto);
        public static IEnumerable<Section> FromDto(this IEnumerable<SectionDto> sectionDto) => sectionDto.Select(FromDto);

    }

    public static class BrandMapper
    {
        public static BrandDto ToDto(this Brand brand) =>
            brand is null
                ? null
                : new BrandDto(brand.Id, brand.Name, brand.Order, brand.Products.Count);

        public static Brand FromDto(this BrandDto brandDto) => brandDto is null
            ? null
            : new Brand()
            {
                Id = brandDto.Id,
                Name = brandDto.Name,
                Order = brandDto.Order,
            };

        public static IEnumerable<BrandDto> ToDto(this IEnumerable<Brand> brands) => brands.Select(ToDto);

        public static IEnumerable<Brand> FromDto(this IEnumerable<BrandDto> brandsDto) => brandsDto.Select(FromDto);
    }
}

