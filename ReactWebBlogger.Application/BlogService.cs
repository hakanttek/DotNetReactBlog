using ReactWebBlogger.Contracts;
using ReactWebBlogger.Contracts.Services;
using ReactWebBlogger.Contracts.Repositories;
using ReactWebBlogger.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactWebBlogger.Services
{
    public class BlogService : IBlogService, ICRUDService<Blog>
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await _blogRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _blogRepository.GetAllAsync();
        }

        public async Task AddBlogAsync(Blog blog)
        {
            await _blogRepository.AddAsync(blog);
            await _blogRepository.SaveAsync();
        }

        public async Task UpdateBlogAsync(Blog blog)
        {
            _blogRepository.Update(blog);
            await _blogRepository.SaveAsync();
        }

        public async Task DeleteBlogAsync(int id)
        {
            await _blogRepository.DeleteAsync(id);
            await _blogRepository.SaveAsync();
        }
    }
}
