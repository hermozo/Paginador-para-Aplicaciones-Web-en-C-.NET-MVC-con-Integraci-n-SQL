using Microsoft.EntityFrameworkCore;
using mvc1.Models;

namespace mvc1
{
    public class AppDBContext : DbContext
    {
        public DbSet<Productos> Productos { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
    }
}
