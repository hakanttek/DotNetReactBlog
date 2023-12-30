using AutoMapper;
using ReactWebBlogger.Contracts;
using ReactWebBlogger.Contracts.Services;
using ReactWebBlogger.Contracts.Repositories;
using ReactWebBlogger.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReactWebBlogger.Application.DTOs;

namespace ReactWebBlogger.Application.Services
{
    public class BlogService : IBlogService<BlogDto>, ICRUDService<BlogDto> // Update interface to use BlogDto
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper; // Add AutoMapper

        public BlogService(IBlogRepository blogRepository, IMapper mapper) // Inject IMapper
        {
            _blogRepository = blogRepository;
            _mapper = mapper; // Initialize IMapper
        }

        public async Task<BlogDto?> GetByIdAsync(int id)
        {
            var blog = await _blogRepository.GetByIdAsync(id);
            return _mapper.Map<BlogDto>(blog); // Map Blog to BlogDto
        }

        public async Task<IEnumerable<BlogDto>> GetAllAsync()
        {
            var blogs = await _blogRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BlogDto>>(blogs); // Map IEnumerable<Blog> to IEnumerable<BlogDto>
        }

        public async Task AddAsync(BlogDto blogDto) // Update parameter to use BlogDto
        {
            var blog = _mapper.Map<Blog>(blogDto); // Map BlogDto to Blog
            await _blogRepository.AddAsync(blog);
            await _blogRepository.SaveAsync();
        }

        public async Task UpdateAsync(BlogDto blogDto) // Update parameter to use BlogDto
        {
            var existingBlog = await _blogRepository.GetByIdAsync(blogDto.Id);
            if (existingBlog == null)
            {
                // Handle not found scenario
                return;
            }

            _mapper.Map(blogDto, existingBlog); // Map BlogDto properties to existingBlog
            _blogRepository.Update(existingBlog);
            await _blogRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _blogRepository.DeleteAsync(id);
            await _blogRepository.SaveAsync();
        }
    }
}
