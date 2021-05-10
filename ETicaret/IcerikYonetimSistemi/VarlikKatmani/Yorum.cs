using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class Yorum
    {
        [Key]
        public int ID { get; set; }

        public int IcerikID { get; set; }

        public string KullaniciID { get; set; }

        public DateTime Tarih { get; set; }

        [Required, MaxLength(1000)]
        public string Metin { get; set; }

        [ForeignKey(nameof(IcerikID))]
        public virtual Icerik Icerik { get; set; }

        [ForeignKey(nameof(KullaniciID))]
        public virtual IdentityUser Kullanici { get; set; }
    }
}
