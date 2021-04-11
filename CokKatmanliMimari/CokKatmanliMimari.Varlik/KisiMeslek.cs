using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CokKatmanliMimari.Varlik
{
    public class KisiMeslek
    {
        [Key]
        public int ID { get; set; }
        public int KisiID { get; set; }
        public int MeslekID { get; set; }

        [ForeignKey("KisiID")]
        public Kisi Kisi{ get; set; }

        [ForeignKey(nameof(MeslekID))]
        public Meslek Meslek{ get; set; }
    }
}
