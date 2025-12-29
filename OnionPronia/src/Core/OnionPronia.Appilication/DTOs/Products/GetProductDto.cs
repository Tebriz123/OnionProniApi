using OnionPronia.Appilication.DTOs.Categories;
using OnionPronia.Appilication.DTOs.Colors;
using OnionPronia.Appilication.DTOs.Sizes;
using OnionPronia.Appilication.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.DTOs.Products
{
    public record GetProductDto(
        long Id,
        string Name,
        decimal Price,
        string SKU,
        string Description,
        GetCategoryInProductDto CategoryDto,
        ICollection<GetTagInProductDto> TagDtos,
        ICollection<GetColorInProductDto> ColorDtos,
        ICollection<GetSizeInProductDto> SizeDtos

        );
    
}
