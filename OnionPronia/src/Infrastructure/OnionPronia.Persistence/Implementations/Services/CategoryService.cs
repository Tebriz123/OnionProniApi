using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionPronia.Appilication.DTOs.Categories;
using OnionPronia.Appilication.Interfaces.Repositories;
using OnionPronia.Appilication.Interfaces.Services;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Persistence.Implementations.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(PostCategoryDto categoryDto)
        {
            
            bool result= await _repository.AnyAsync(c=>c.Name==categoryDto.Name);
            if (result)
            {
                throw new Exception("Category Name Existed");
            }


            Category category = _mapper.Map<Category>(categoryDto);
            category.CreatedAt = DateTime.Now;
            //Category category = new()
            //{
            //    Name = categoryDto.Name,
            //    CreatedAt= DateTime.Now
            //};

            _repository.Add(category);
            await _repository.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<GetCategoryItemDto>> GetAllAsync(int page, int take)
        {


            var categories = await _repository
                .GetAll(
               sort: c => c.Name,
               page: page,
               take: take,
               includes: nameof(Category.Products)
               ).ToListAsync();
            
            return _mapper.Map<IReadOnlyList<GetCategoryItemDto>>(categories);


        }

        public async Task<GetCategoryDto> GetByIdAsync(int id)
        {
            Category? category = await _repository.GetByIdAsync(id, nameof(Category.Products));

            if (category is null) throw new Exception("Category not found");

            return _mapper.Map<GetCategoryDto>(category);

                //new GetCategoryDto(
                //category.Id,
                //category.Name,
                //category.Products.Select(p => new GetProductInCategoryDto(p.Id, p.Name, p.Price)));
        }

        public async Task UpdateAsync(PutCategoryDto categoryDto, int id)
        {
            Category? category = await _repository.GetByIdAsync(id);



            if (category is null) throw new Exception("Category not found");

            category = _mapper.Map(categoryDto,category);

            //category.Name = categoryDto.Name;
            category.UpdatedAt = DateTime.Now;

            _repository.Update(category);
            await _repository.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            Category? category = await _repository.GetByIdAsync(id);
            if (category is null) throw new Exception("Category not found");

            _repository.Remove(category);
            await _repository.SaveChangesAsync();
        }
    }
}
