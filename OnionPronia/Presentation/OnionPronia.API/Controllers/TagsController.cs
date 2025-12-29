using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionPronia.Appilication.DTOs.Categories;
using OnionPronia.Appilication.DTOs.Tags;
using OnionPronia.Appilication.Interfaces.Repositories;
using OnionPronia.Appilication.Interfaces.Services;

namespace OnionPronia.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagRepository _repository;
        private readonly ITagService _service;

        public TagsController(ITagRepository repository,ITagService service)
        {
            _repository = repository;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page, int take)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1) return BadRequest();


            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PostTagDto tagDto)
        {
            await _service.CreateAsync(tagDto);

            return Created();

        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, [FromForm] PutTagDto tagDto)
        {
            if (id < 1) return BadRequest();
            await _service.UpdateAsync(tagDto, id);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            await _service.RemoveAsync(id);

            return NoContent();
        }

    }
}
