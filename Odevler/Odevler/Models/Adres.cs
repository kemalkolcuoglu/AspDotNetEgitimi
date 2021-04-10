using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Odevler.Models
{
    public class Adres
    {
        [Key]
        public int ID { get; set; }
        public int IlKodu { get; set; }
        [Required, MaxLength(127)]
        public string AcikAdres{ get; set; }
        public int KisiID { get; set; }

        [ForeignKey(nameof(KisiID))]
        public Kisi Kisi { get; set; }
    }
}
