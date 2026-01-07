using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnionPronia.Appilication.DTOs.AppUsers;
using OnionPronia.Appilication.Interfaces.Services;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Persistence.Implementations.Services
{
    internal class AuthenticationService: IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AuthenticationService(UserManager<AppUser> userManager,IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task RegisterAsync(RegisterDto userDto)
        {
            await _userManager.CreateAsync(_mapper.Map<AppUser>(userDto), userDto.Password);
        }

    }
}
