using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactWebBlogger.Contracts.Services
{
    public interface ICRUDService<TDto> where TDto : class
    {
        Task<TDto?> GetByIdAsync(int id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task AddAsync(TDto dto);
        Task UpdateAsync(TDto dto);
        Task DeleteAsync(int id);
    }

}
