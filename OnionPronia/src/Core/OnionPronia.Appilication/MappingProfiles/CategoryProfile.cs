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
            CreateMap<Category, GetCategoryItemDto>();

            CreateMap<Category, GetCategoryDto>();

            CreateMap<PostCategoryDto, Category>();

            CreateMap<PutCategoryDto, Category>();
        }

    }
}
