using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Odevler.Models
{
    public class Not
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(1000)]
        public string Detay { get; set; }

        public int Oncelik { get; set; }

        [MaxLength(30)]
        public string Renk { get; set; }

        public DateTime Tarih { get; set; }
    }
}
