using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactWebBlogger.Contracts.Services
{
    public interface IUserService<UserDto> : ICRUDService<UserDto> where UserDto : class
    {
        Task<UserDto?> GetUserByUsernameAsync(string username);
    }
}
