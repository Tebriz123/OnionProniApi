using OnionPronia.Appilication.DTOs.Colors;
using OnionPronia.Appilication.DTOs.Sizes;
using OnionPronia.Appilication.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.Interfaces.Services
{
    public interface IColorService
    {
        Task<IReadOnlyList<GetColorItemDto>> GetAllAsync(int page, int take);
        Task<GetColorDto> GetByIdAsync(int id);
        Task CreateAsync(PostColorDto colorDto);

        Task UpdateAsync(PutColorDto colorDto, int id);
        Task RemoveAsync(int id);
    }
}
