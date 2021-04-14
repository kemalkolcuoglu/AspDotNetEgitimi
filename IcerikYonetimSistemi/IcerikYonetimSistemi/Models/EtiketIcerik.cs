using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IcerikYonetimSistemi.Models
{
    public class EtiketIcerik
    {
        [Key]
        public int ID { get; set; }
        public int IcerikID { get; set; }
        public int EtiketID { get; set; }

        public virtual Icerik Icerik { get; set; }
        public virtual Etiket Etiket { get; set; }
    }
}
