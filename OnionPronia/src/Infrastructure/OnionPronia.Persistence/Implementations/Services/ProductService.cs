using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionPronia.Appilication.DTOs.Products;
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
    internal class ProductService:IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ISizeRepository _sizeRepository;

        public ProductService(
            IProductRepository repository, 
            IMapper mapper,
            ICategoryRepository categoryRepository,
            ITagRepository tagRepository,
            IColorRepository colorRepository,
            ISizeRepository sizeRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
        }

        public async Task<IReadOnlyList<GetProductItemDto>> GetAllAsync(int page, int take)
        {
          IReadOnlyList<Product> products = await _repository.GetAll(
                page: page,
                take: take,
                includes:nameof(Product.Category)

                ).ToListAsync();
           return _mapper.Map<IReadOnlyList<GetProductItemDto>>(products); 
        }

        public async Task<GetProductDto> GetByIdAsync(long id)
        {
            Product product = await _repository.GetByIdAsync(id,"ProductTags.Tag",nameof(Product.Category),"ProductColors.Color","ProductSizes.Size");

            if (product is null) throw new Exception("Entity not found");

            return _mapper.Map<GetProductDto>(product);
        }

        public async Task CreateProductAsync(PostProductDto productDto)
        {
            bool result = await _repository.AnyAsync(p => p.Name == productDto.Name);
            if (result)
            {
                throw new Exception("Entity already exists");
            }

            bool categoryResult = await _categoryRepository.AnyAsync(c=>c.Id==productDto.CategoryId);
            if(!categoryResult)
            {
                throw new Exception("Category does not exists");
            }
             var tags = await _tagRepository.GetAll(t=>productDto.TagIds.Distinct().Contains(t.Id)).ToListAsync();

            if (tags.Count != productDto.TagIds.Count())
            {
                throw new Exception("Tag does not exists");
            }
            var colors = await _colorRepository.GetAll(c => productDto.ColorIds.Distinct().Contains(c.Id)).ToListAsync();

            if (colors.Count != productDto.ColorIds.Count())
            {
                throw new Exception("Color does not exists");
            }
            var sizes = await _sizeRepository.GetAll(s => productDto.SizeIds.Distinct().Contains(s.Id)).ToListAsync();

            if (sizes.Count != productDto.SizeIds.Count())
            {
                throw new Exception("Size does not exists");
            }

            Product product = _mapper.Map<Product>(productDto);


            _repository.Add(product);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(long id, PutProductDto productDto)
        {
            bool result = await _repository.AnyAsync(p => p.Name == productDto.Name && p.Id !=id);

            if (result)
            {
                throw new Exception("Entity already exists");
            }

            bool categoryResult = await _categoryRepository.AnyAsync(c => c.Id == productDto.CategoryId);
            if (!categoryResult)
            {
                throw new Exception("Category does not exists");
            }

            var tags = await _tagRepository.GetAll(t => productDto.TagIds.Distinct().Contains(t.Id)).ToListAsync();

            if (tags.Count != productDto.TagIds.Count())
            {
                throw new Exception("Tag does not exists");
            }
            var colors = await _colorRepository.GetAll(c => productDto.ColorIds.Distinct().Contains(c.Id)).ToListAsync();

            if (colors.Count != productDto.ColorIds.Count())
            {
                throw new Exception("Color does not exists");
            }
            var sizes = await _sizeRepository.GetAll(s => productDto.SizeIds.Distinct().Contains(s.Id)).ToListAsync();

            if (sizes.Count != productDto.SizeIds.Count())
            {
                throw new Exception("Size does not exists");
            }


            Product product = await _repository.GetByIdAsync(id,"ProductTags","ProductColors","ProductSizes");
            
            _repository.Update(_mapper.Map(productDto,product));
            await _repository.SaveChangesAsync();
            

        }
    }
}
