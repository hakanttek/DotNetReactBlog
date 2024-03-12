using Microsoft.EntityFrameworkCore;
using ReactWebBlogger.Contracts.Repositories;
using ReactWebBlogger.Domain.Entities;
using ReactWebBlogger.Infrastructure.Data;

namespace ReactWebBlogger.Infrastructure
{
    public class GameRepository : ICRUDRepository<Game>, IGameRepository
    {
        private readonly LocalDbContext _context;

        public GameRepository(LocalDbContext context)
        {
            _context = context;
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task AddAsync(Game game)
        {
            await _context.Games.AddAsync(game);
        }

        public void Update(Game game)
        {
            _context.Games.Update(game);
        }

        public async Task DeleteAsync(int id)
        {
            var game = await _context.Blogs.FindAsync(id);
            if (game != null)
            {
                _context.Blogs.Remove(game);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}