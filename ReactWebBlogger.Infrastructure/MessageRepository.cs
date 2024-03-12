using Microsoft.EntityFrameworkCore;
using ReactWebBlogger.Contracts.Repositories;
using ReactWebBlogger.Domain.Entities;
using ReactWebBlogger.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactWebBlogger.Infrastructure
{
    public class MessageRepository : IMessageRepository, ICRUDRepository<Message>
    {
        private readonly LocalDbContext _context;

        public MessageRepository(LocalDbContext context)
        {
            _context = context;
        }

        public async Task<Message?> GetByIdAsync(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<IEnumerable<Message>> GetAllAsync()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task AddAsync(Message entity)
        {
            await _context.Messages.AddAsync(entity);
        }

        public void Update(Message entity)
        {
            _context.Messages.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message != null)
            {
                _context.Messages.Remove(message);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
