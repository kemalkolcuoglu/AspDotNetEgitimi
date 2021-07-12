using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIWithEFC.Models
{
    public class Kisi
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(15)]
        public string Ad { get; set; }

        [Required, MaxLength(15)]
        public string Soyad { get; set; }
    }
}
