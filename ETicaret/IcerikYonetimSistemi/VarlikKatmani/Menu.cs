using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class Menu
    {
        public Menu()
        {
            Sayfalar = new List<Sayfa>();
        }

        [Key]
        public int ID { get; set; }

        [Required, MaxLength(100), DisplayName("Başlık")]
        public string Baslik { get; set; }

        [MaxLength(15), DisplayName("İkon")]
        public string Ikon { get; set; }

        [MaxLength(15), DisplayName("Ek Alan")]
        public string EkAlan { get; set; }

        [DisplayName("Açılır Menü Mü?")]
        public bool AcilirMenuMu { get; set; }

        [DefaultValue(true)]
        public bool Etkin { get; set; }

        public List<Sayfa> Sayfalar { get; set; }
    }
}
