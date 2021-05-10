using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class UrunYorum
    {
        [Key]
        public int Id { get; set; }

        public int UrunId { get; set; }

        public string KullaniciId { get; set; }

        public DateTime Tarih { get; set; }

        [Required, MaxLength(1000)]
        public string Metin { get; set; }

        [Required]
        public sbyte Puan { get; set; }

        [ForeignKey(nameof(UrunId))]
        public virtual Urun Urun { get; set; }

        [ForeignKey(nameof(KullaniciId))]
        public virtual IdentityUser Kullanici { get; set; }
    }
}
