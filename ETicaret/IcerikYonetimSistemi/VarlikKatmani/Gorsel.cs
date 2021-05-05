using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class Gorsel
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(40), DisplayName("Başlık")]
        public string Baslik { get; set; }

        [Required, MaxLength(128)]
        public string Yol { get; set; }

        [DefaultValue(true)]
        public bool Etkin { get; set; }
    }
}
