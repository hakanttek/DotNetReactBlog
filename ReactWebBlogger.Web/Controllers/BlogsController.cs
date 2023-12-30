using Microsoft.AspNetCore.Mvc;
using ReactWebBlogger.Contracts.Services;
using ReactWebBlogger.Application.DTOs; // Import BlogDto

namespace ReactWebBlogger.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService<BlogDto> _blogService; // Update interface to use BlogDto

        public BlogController(IBlogService<BlogDto> blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _blogService.GetAllAsync();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BlogDto blogDto) // Update parameter to use BlogDto
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _blogService.AddAsync(blogDto); // Update method to use BlogDto
            return CreatedAtAction(nameof(GetById), new { id = blogDto.Id }, blogDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BlogDto blogDto) // Update parameters to use BlogDto
        {
            if (id != blogDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _blogService.UpdateAsync(blogDto); // Update method to use BlogDto
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            await _blogService.DeleteAsync(id);
            return NoContent();
        }
    }
}
