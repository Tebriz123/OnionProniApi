using FluentValidation;
using OnionPronia.Appilication.DTOs.AppUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.Validator
{
    public class LoginDtoValidator:AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(u => u.UsernameOrEmail)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(256);
            RuleFor(u => u.Password)
               .NotEmpty()
               .MinimumLength(8);
        }
    }
}
