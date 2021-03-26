using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreGiris.Models
{
    public class Yazar
    {
        public Yazar()
        {
            Kitaplar = new HashSet<Kitap>();
        }

        [Key]
        public int ID { get; set; }

        public string Ad { get; set; }

        public virtual ICollection<Kitap> Kitaplar { get; set; }
    }
}
