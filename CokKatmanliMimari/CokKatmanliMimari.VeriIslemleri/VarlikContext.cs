using CokKatmanliMimari.Varlik;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CokKatmanliMimari.VeriIslemleri
{
    public class VarlikContext : DbContext
    {
        public VarlikContext(DbContextOptions<VarlikContext> options) : base(options)
        {
        }

        public DbSet<Kisi> Kisi { get; set; }
        public DbSet<Meslek> Meslek { get; set; }
        public DbSet<KisiMeslek> KisiMeslek { get; set; }
    }
}
