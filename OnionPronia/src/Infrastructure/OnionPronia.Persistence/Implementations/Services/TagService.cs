using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionPronia.Appilication.DTOs.Categories;
using OnionPronia.Appilication.DTOs.Products;
using OnionPronia.Appilication.DTOs.Tags;
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
    internal class TagService:ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GetTagItemDto>> GetAllAsync(int page, int take)
        { 
            IReadOnlyList<Tag> tags = await _repository.GetAll(
                page:page,
                take:take
                ).ToListAsync();
            return _mapper.Map<IReadOnlyList<GetTagItemDto>>(tags);
        }

        public async Task<GetTagDto> GetByIdAsync(int id)
        {
            Tag? tag = await _repository.GetByIdAsync(id);

            if (tag is null) throw new Exception("Tag not found");

            return _mapper.Map<GetTagDto>(tag);

        }

        public async Task CreateAsync(PostTagDto tagDto)
        {

            bool result = await _repository.AnyAsync(t => t.Name == tagDto.Name);
            if (result)
            {
                throw new Exception("Tag Name Existed");
            }


            Tag tag = _mapper.Map<Tag>(tagDto);
            tag.CreatedAt = DateTime.Now;
           
            _repository.Add(tag);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateAsync(PutTagDto tagDto, int id)
        {
            Tag? tag = await _repository.GetByIdAsync(id);



            if (tag is null) throw new Exception("Tag not found");

            tag = _mapper.Map(tagDto, tag);

            tag.UpdatedAt = DateTime.Now;

            _repository.Update(tag);
            await _repository.SaveChangesAsync();
        }
        public async Task RemoveAsync(int id)
        {
            Tag? tag = await _repository.GetByIdAsync(id);
            if (tag is null) throw new Exception("Tag not found");

            _repository.Remove(tag);
            await _repository.SaveChangesAsync();
        }
    }
}
