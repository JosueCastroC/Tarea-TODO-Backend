using Microsoft.EntityFrameworkCore;
namespace TodoApi.Models
{
    public class TODODbContext : DbContext
    {
        public TODODbContext(DbContextOptions<TODODbContext> opts) : base(opts)
        {
        }
        public DbSet<TODOMessage> Todos { get; set; }
        public DbSet<Miembros> Miembros { get; set; }
        public DbSet<Membresia> Membresia { get; set; }


    }

}
