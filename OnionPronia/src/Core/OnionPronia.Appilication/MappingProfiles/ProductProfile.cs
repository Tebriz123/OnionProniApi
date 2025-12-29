using AutoMapper;
using OnionPronia.Appilication.DTOs.Colors;
using OnionPronia.Appilication.DTOs.Products;
using OnionPronia.Appilication.DTOs.Sizes;
using OnionPronia.Appilication.DTOs.Tags;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.MappingProfiles
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductInCategoryDto>();
            CreateMap<Product, GetProductItemDto>()
                .ForCtorParam(nameof(GetProductItemDto.CategoryName),
                opt => opt.MapFrom(p => p.Category.Name));

            CreateMap<Product, GetProductDto>()
                .ForCtorParam(nameof(GetProductDto.CategoryDto),
                opt => opt.MapFrom(p => p.Category))

                .ForCtorParam(nameof(GetProductDto.TagDtos),
                opt => opt.MapFrom(p => p.ProductTags
                    .Select(pt => new GetTagInProductDto(pt.Tag.Id, pt.Tag.Name))
                    .ToList()))

                .ForCtorParam(nameof(GetProductDto.ColorDtos),
                 opt => opt.MapFrom(p => p.ProductColors
                     .Select(pc => new GetColorInProductDto(pc.Color.Id, pc.Color.Name))
                      .ToList()))

                .ForCtorParam(nameof(GetProductDto.SizeDtos),
                opt=>opt.MapFrom(p => p.ProductSizes
                .Select(ps=>new GetSizeInProductDto(ps.Size.Id,ps.Size.Name))
                .ToList()));

        }
    }
}
