using Microsoft.EntityFrameworkCore;
using Odevler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odevler.Data
{
    public class OdevContext : DbContext
    {
        public OdevContext(DbContextOptions<OdevContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blog { get; set; }
        public DbSet<Not> Not { get; set; }
        public DbSet<Anket> Anket { get; set; }
        public DbSet<Sonuc> Sonuc { get; set; }

        public DbSet<Kisi> Kisi { get; set; }
        public DbSet<Adres> Adres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().ToTable("Blog");
        }
    }
}
