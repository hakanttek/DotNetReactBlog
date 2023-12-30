using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactWebBlogger.Contracts.Services
{
    public interface IBlogService<BlogDto> : ICRUDService<BlogDto> where BlogDto : class
    {
    }
}
