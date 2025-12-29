using AutoMapper;
using OnionPronia.Appilication.DTOs.Categories;
using OnionPronia.Appilication.DTOs.Tags;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.MappingProfiles
{
    internal class TagProfile:Profile
    {

        public TagProfile()
        {
            CreateMap<Tag, GetTagItemDto>();
            CreateMap<Tag, GetTagInProductDto>();
            CreateMap<PostTagDto, Tag>();

            CreateMap<PutTagDto, Tag>();
            CreateMap<Tag, GetTagDto>();
        }
    }
}
