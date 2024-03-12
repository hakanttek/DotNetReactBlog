using ReactWebBlogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactWebBlogger.Contracts.Repositories
{
    public interface IMessageRepository : ICRUDRepository<Message>
    {
    }
}
