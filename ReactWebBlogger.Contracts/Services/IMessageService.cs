using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactWebBlogger.Contracts.Services
{
    public interface IMessageService<MessageDto> : ICRUDService<MessageDto> where MessageDto : class
    {
    }
}
