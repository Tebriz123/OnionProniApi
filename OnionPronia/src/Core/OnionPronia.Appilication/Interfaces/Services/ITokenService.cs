using OnionPronia.Appilication.DTOs.Tokens;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.Interfaces.Services
{
    public interface ITokenService
    {
        TokenResponseDto CreateAccessToken(AppUser user, int minutes);
    }
}
