
using AutoMapper;
using OnionPronia.Appilication.DTOs.Sizes;
using OnionPronia.Domain.Entities;
using System.Drawing;
using Size = OnionPronia.Domain.Entities.Size;

namespace OnionPronia.Appilication.MappingProfiles
{
    internal class SizeProfile:Profile
    {

        public SizeProfile()
        {
            CreateMap<Size, GetSizeInProductDto>();
        }

      
    }

}
