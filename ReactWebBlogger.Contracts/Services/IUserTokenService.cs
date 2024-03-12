using ReactWebBlogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactWebBlogger.Contracts.Services
{
    public interface IUserTokenService<UserDto> : ITokenService<UserDto>
    {
    }
}
