using Microsoft.EntityFrameworkCore;

namespace DbWork2
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Human> Humans { get; set; }
    }
}