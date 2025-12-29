using AutoMapper;
using OnionPronia.Appilication.DTOs.Colors;
using OnionPronia.Appilication.DTOs.Tags;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.MappingProfiles
{
    internal class ColorProfile:Profile
    {

        public ColorProfile()
        {
            CreateMap<Color, GetColorItemDto>();
            CreateMap<Color, GetColorInProductDto>();
            CreateMap<PostColorDto, Color>();

            CreateMap<PutColorDto, Color>();
            CreateMap<Color, GetColorDto>();
        }
    }
}
