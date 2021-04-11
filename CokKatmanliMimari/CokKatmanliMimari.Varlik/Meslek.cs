using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CokKatmanliMimari.Varlik
{
    public class Meslek
    {
        public Meslek()
        {
            KisiMeslek = new List<KisiMeslek>();
        }

        [Key]
        public int ID { get; set; }

        [MaxLength(25), Required]
        public string Ad { get; set; }

        public List<KisiMeslek> KisiMeslek { get; set; }
    }
}
