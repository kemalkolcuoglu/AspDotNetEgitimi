using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Odevler.Models
{
    public class Sonuc
    {
        [Key]
        public int ID { get; set; }

        public int SoruID { get; set; }

        public int Cevap { get; set; }
    }
}
