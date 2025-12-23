using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.DTOs.Categories
{
    public record GetCategoryItemDto(
       int id,
       string Name,
       int ProductCount
       );
}
