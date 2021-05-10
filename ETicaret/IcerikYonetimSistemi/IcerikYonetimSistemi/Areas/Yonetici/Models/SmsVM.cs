using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IcerikYonetimSistemi.Areas.Yonetici.Models
{
    public class SmsVM
    {
        [Required]
        public string Gsmno { get; set; }

        [Required, MaxLength(16)]
        public string MesajBasligi { get; set; }

        [Required, MaxLength(850)]
        public string Mesaj { get; set; }
    }
}
