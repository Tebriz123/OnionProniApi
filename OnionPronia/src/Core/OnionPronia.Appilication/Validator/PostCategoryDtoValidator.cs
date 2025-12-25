using FluentValidation;
using OnionPronia.Appilication.DTOs.Categories;
using OnionPronia.Appilication.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.Validator
{
    public class PostCategoryDtoValidator:AbstractValidator<PostCategoryDto>
    {
        private const int MAX_LIMIT = 150;
        private const int MIN_LIMIT = 2;
        public PostCategoryDtoValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name is required")
                .MaximumLength(MAX_LIMIT)
                    .WithMessage("Name must be less than 150 characters")
                .MinimumLength(MIN_LIMIT)
                    .WithMessage("Name must be more than 1 characters")
                .Matches(@"^[A-Za-z0-9\s]$");

                //.Must(CheckName)
                //.WithMessage("Custom yoxlamasi"); 
               
        }


        //public bool CheckName(string name)
        //{
          
        //        return name.Contains("t") && name.StartsWith("C");
        //}

    }
}
