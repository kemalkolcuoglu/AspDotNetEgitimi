using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWithEFC.Models;

namespace WebAPIWithEFC.Context
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {
        }

        public DbSet<Kisi> Kisiler { get; set; }

        public DbSet<Sayilar> Sayilar { get; set; }
    }
}
