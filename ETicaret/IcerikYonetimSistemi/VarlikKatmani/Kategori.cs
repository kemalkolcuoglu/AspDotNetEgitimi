using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class Kategori
    {
        public Kategori()
        {
            Urun = new List<Urun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int Parent { get; set; }

        [Required, MaxLength(32), DisplayName("Başlık")]
        public string Baslik { get; set; }

        [Required, MaxLength(6)]
        public string Renk { get; set; } // #FF0000 -> Kırmızı #Hexadecimal -> 16'lık tabanda Sayılar

        [MaxLength(15), DisplayName("Ek Alan")]
        public string EkAlan { get; set; }

        public List<Urun> Urun { get; set; }
    }
}
