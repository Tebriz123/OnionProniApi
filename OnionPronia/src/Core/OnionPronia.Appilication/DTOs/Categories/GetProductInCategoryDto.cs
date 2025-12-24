using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.DTOs.Categories
{
    public record GetProductInCategoryDto(
        long id,
        string Name,
        decimal Price
        );
}
