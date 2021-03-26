using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreGiris.Models
{
    public class Kitap
    {
        [Key]
        public int ID { get; set; }

        public string Ad{ get; set; }

        public string Tur { get; set; }

        public double Fiyat { get; set; }

        public int YazarID { get; set; }

        [ForeignKey("YazarID")]
        public virtual Yazar Yazar { get; set; }
    }
}
