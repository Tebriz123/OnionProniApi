using OnionPronia.Appilication.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Appilication.Interfaces.Services
{
    public interface ICategoryService
    {
        public Task<IReadOnlyList<GetCategoryItemDto>> GetAllAsync(int page, int take);

        public Task<GetCategoryDto> GetByIdAsync(int id);

        public Task CreateAsync(PostCategoryDto categoryDto);
        Task UpdateAsync(PutCategoryDto categoryDto, int id);

        Task RemoveAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
