using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class SimpleServerContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public SimpleServerContext(DbContextOptions options) : base(options) { }
    }
}
