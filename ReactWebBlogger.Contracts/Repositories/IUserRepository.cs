using ReactWebBlogger.Domain.Entities;

namespace ReactWebBlogger.Contracts.Repositories
{
    public interface IUserRepository : ICRUDRepository<User>
    {
        Task<User?> GetUserByUsernameAsync(string username);
    }
}