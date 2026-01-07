using AutoMapper;
using OnionPronia.Appilication.DTOs.AppUsers;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.MappingProfiles
{
    internal class AppUserProfile:Profile
    {

        public AppUserProfile()
        {
            CreateMap<RegisterDto, AppUser>();
        }
    }
}
