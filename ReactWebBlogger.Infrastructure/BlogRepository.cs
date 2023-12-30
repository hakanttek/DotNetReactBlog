using Microsoft.EntityFrameworkCore;
using ReactWebBlogger.Contracts.Repositories;
using ReactWebBlogger.Domain.Entities;
using ReactWebBlogger.Infrastructure.Data;

namespace ReactWebBlogger.Infrastructure
{
    public class BlogRepository : ICRUDRepository<Blog>, IBlogRepository
    {
        private readonly LocalDbContext _context;

        public BlogRepository(LocalDbContext context)
        {
            _context = context;
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task AddAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
        }

        public void Update(Blog blog)
        {
            _context.Blogs.Update(blog);
        }

        public async Task DeleteAsync(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}