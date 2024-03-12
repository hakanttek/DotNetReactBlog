using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactWebBlogger.Contracts.Services
{
    public interface IGameService<GameDto> : ICRUDService<GameDto> where GameDto : class
    {
    }
}
