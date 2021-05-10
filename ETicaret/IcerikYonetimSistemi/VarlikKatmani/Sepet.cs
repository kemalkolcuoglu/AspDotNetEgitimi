using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class Sepet
    {
        [Key]
        public int Id { get; set; }

        public int UrunId { get; set; }

        public string KullaniciId { get; set; }

        public int Miktar { get; set; }

        public decimal Tutar { get; set; }

        [ForeignKey(nameof(UrunId))]
        public Urun Urun { get; set; }

        [ForeignKey(nameof(KullaniciId))]
        public IdentityUser Kullanici { get; set; }
    }
}
