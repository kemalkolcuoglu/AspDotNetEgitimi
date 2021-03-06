using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class FavoriListesi
    {
        [Key]
        public int Id { get; set; }

        public string KullaniciId { get; set; }

        public int UrunId { get; set; }

        [ForeignKey(nameof(KullaniciId))]
        public IdentityUser Kullanici { get; set; }

        [ForeignKey(nameof(UrunId))]
        public Urun Urun { get; set; }
    }
}
