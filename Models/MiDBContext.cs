using Microsoft.EntityFrameworkCore;
namespace CoctelesExamen.Models
{
    public class MiDBContext : DbContext
    {
        public DbSet<CoctelesFavoritos> Favoritos { get; set; }

        public DbSet<Coctel> Cocteles { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }

        public MiDBContext(DbContextOptions<MiDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
