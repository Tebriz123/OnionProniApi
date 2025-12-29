using OnionPronia.Appilication.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.Interfaces.Services
{
    public interface ITagService
    {
        Task<IReadOnlyList<GetTagItemDto>> GetAllAsync(int page, int take);
        Task<GetTagDto> GetByIdAsync(int id);
        Task CreateAsync(PostTagDto tagDto);

        Task UpdateAsync(PutTagDto tagDto, int id);
        Task RemoveAsync(int id);

    }
}
