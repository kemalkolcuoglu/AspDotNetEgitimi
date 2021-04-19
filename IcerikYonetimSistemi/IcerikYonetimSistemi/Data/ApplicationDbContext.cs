using IcerikYonetimSistemi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IcerikYonetimSistemi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EtiketIcerik> EtiketIcerik { get; set; }
        public DbSet<Etiket> Etiket { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<Gorsel> Gorsel { get; set; }
        public DbSet<Icerik> Icerik { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Sayfa> Sayfa { get; set; }
    }
}
