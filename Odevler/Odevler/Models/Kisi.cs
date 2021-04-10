using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Odevler.Models
{
    public class Kisi
    {
        public Kisi()
        {
            Adresler = new List<Adres>();
        }

        [Key]
        public int ID { get; set; }
        [Required, MaxLength(15)]
        public string Ad { get; set; }
        [Required, MaxLength(15)]
        public string Soyad { get; set; }
        public int Yas { get; set; }

        public virtual List<Adres> Adresler { get; set; }
    }
}
