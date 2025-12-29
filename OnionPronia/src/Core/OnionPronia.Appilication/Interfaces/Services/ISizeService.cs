using OnionPronia.Appilication.DTOs.Sizes;
using OnionPronia.Appilication.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.Interfaces.Services
{
    public interface ISizeService
    {
        Task<IReadOnlyList<GetSizeItemDto>> GetAllAsync(int page, int take);
        Task<GetSizeDto> GetByIdAsync(int id);
        Task CreateAsync(PostSizeDto sizeDto);

        Task UpdateAsync(PutSizeDto sizeDto, int id);
        Task RemoveAsync(int id);
    }
}
