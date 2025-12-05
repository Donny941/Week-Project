using Microsoft.EntityFrameworkCore;

namespace Polizia_Municipale.Models.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Verbale> Verbali { get; set; }
        public DbSet<Anagrafica> Anagrafiche { get; set; }
        public DbSet<Violazione> Violazioni { get; set; }


    }


}
