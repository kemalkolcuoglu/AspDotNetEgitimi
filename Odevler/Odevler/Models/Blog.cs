using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Odevler.Models
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(30)]
        public string Baslik { get; set; }

        [Required]
        public DateTime Tarih { get; set; }

        [Required, MaxLength(30)]
        public string Yazar { get; set; }

        [Required, MaxLength(1000)]
        public string Icerik { get; set; }
    }
}
