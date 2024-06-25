using Microsoft.EntityFrameworkCore;
using MyTestMVC.Datas.Entities;

namespace MyTestMVC.Datas
{
    public class AppDbContext : DbContext
    {
        public DbSet<Events> Events { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
