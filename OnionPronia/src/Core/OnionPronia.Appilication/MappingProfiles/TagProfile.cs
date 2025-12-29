using AutoMapper;
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
            CreateMap<Tag, GetTagInProductDto>();
        }
    }
}
