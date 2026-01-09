using OnionPronia.Appilication.DTOs.AppUsers;
using OnionPronia.Appilication.DTOs.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task RegisterAsync(RegisterDto userDto);
        Task<TokenResponseDto> LoginAsync(LoginDto userDto);
    }
}
