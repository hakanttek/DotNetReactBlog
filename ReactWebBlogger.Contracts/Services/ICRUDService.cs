using ReactWebBlogger.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactWebBlogger.Contracts.Services
{
    public interface ICRUDService<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddBlogAsync(T blog);
        Task UpdateBlogAsync(T blog);
        Task DeleteBlogAsync(int id);
    }
}
