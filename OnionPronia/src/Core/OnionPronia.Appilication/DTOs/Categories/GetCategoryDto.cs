using OnionPronia.Appilication.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.DTOs.Categories
{
    public record GetCategoryDto(
       long Id,
       string Name,
       IEnumerable<GetProductInCategoryDto> ProductDtos
       );
}
