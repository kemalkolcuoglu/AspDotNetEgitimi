using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CokKatmanliMimari.Varlik
{
    public class Kisi
    {
        public Kisi()
        {
            KisiMeslek = new List<KisiMeslek>();
        }

        [Key]
        public int ID { get; set; }

        [Required, MaxLength(15)]
        public string Ad { get; set; }

        [Required, MaxLength(15)]
        public string Soyad { get; set; }

        [Required, Range(1, 85)]
        public int Yas { get; set; }

        public List<KisiMeslek> KisiMeslek { get; set; }
    }
}
