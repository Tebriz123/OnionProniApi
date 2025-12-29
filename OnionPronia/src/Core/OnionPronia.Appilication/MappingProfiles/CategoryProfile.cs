using AutoMapper;
using OnionPronia.Appilication.DTOs.Categories;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.MappingProfiles
{
    internal class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, GetCategoryItemDto>()
                .ForCtorParam(nameof(GetCategoryItemDto.ProductCount),
                opt => opt.MapFrom(c => c.Products.Count));
                
                //.ForMember(
                //c=>c.ProductCount,
                //opt=>opt.MapFrom(c=>c.Products.Count)
                //);

            CreateMap<Category, GetCategoryDto>()
                .ForCtorParam(nameof(GetCategoryDto.ProductDtos)
                ,opt=>opt.MapFrom(c=>c.Products));

            CreateMap<Category, GetCategoryInProductDto>();
            CreateMap<PostCategoryDto, Category>();

            CreateMap<PutCategoryDto, Category>();
        }

    }
}
