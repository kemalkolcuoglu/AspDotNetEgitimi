using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreGiris.Models
{
    public class EFCoreGirisContext : DbContext
    {
        public EFCoreGirisContext(DbContextOptions<EFCoreGirisContext> options) : base(options)
        {
        }

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kitap>().ToTable("Kitap");
            modelBuilder.Entity<Yazar>().ToTable("Yazar");
        }
    }
}
