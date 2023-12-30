using Microsoft.EntityFrameworkCore;
using ReactWebBlogger.Domain.Entities;
using System.Collections.Generic;

namespace ReactWebBlogger.Infrastructure.Data
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }

    }
}
