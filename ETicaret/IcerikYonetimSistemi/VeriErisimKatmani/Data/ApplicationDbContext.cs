using VarlikKatmani;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VeriErisimKatmani.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-U5C568K;Database=ETicaretUygulamasi;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Adres> Adres { get; set; }
        public DbSet<EtiketIcerik> EtiketIcerik { get; set; }
        public DbSet<Etiket> Etiket { get; set; }
        public DbSet<Fatura> Fatura { get; set; }
        public DbSet<FavoriListesi> FavoriListesi { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<Gorsel> Gorsel { get; set; }
        public DbSet<Icerik> Icerik { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<KullaniciAdres> KullaniciAdres { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Sepet> Sepet { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<UrunGaleri> UrunGaleri { get; set; }
        public DbSet<UrunYorum> UrunYorum { get; set; }
        public DbSet<Sayfa> Sayfa { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
    }
}
