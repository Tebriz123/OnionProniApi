
using AutoMapper;
using OnionPronia.Appilication.DTOs.Sizes;
using OnionPronia.Appilication.DTOs.Tags;
using OnionPronia.Domain.Entities;
using System.Drawing;
using Size = OnionPronia.Domain.Entities.Size;

namespace OnionPronia.Appilication.MappingProfiles
{
    internal class SizeProfile:Profile
    {

        public SizeProfile()
        {
            CreateMap<Size, GetSizeItemDto>();
            CreateMap<Size, GetSizeInProductDto>();
            CreateMap<PostSizeDto, Size>();

            CreateMap<PutSizeDto, Size>();
            CreateMap<Size, GetSizeDto>();
        }

      
    }

}
