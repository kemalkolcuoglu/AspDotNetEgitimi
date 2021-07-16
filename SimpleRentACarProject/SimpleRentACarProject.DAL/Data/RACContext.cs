using Microsoft.EntityFrameworkCore;
using SimpleRentACarProject.Entity;

namespace SimpleRentACarProject.DAL.Data
{
    public class RACContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-U5C568K;Database=RACPDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public RACContext()
        {
        }

        public RACContext(DbContextOptions<RACContext> options) : base(options)
        {
        }

        public DbSet<Arac> Araclar { get; set; }

        public DbSet<Musteri> Musteriler { get; set; }

        public DbSet<MusteriArac> MusteriAraclar { get; set; }
    }
}
