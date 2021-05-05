using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class Sayfa : TemelModel
    {
        public Sayfa()
        {
            Icerikler = new List<Icerik>();
        }

        [DisplayName("Menü ID")]
        public int MenuID { get; set; }

        [ForeignKey(nameof(MenuID))]
        public Menu Menu { get; set; }

        public List<Icerik> Icerikler { get; set; }
    }
}
