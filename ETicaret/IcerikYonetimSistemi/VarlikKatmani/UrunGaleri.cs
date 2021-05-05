using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class UrunGaleri
    {
        public int UrunId { get; set; }

        public int GorselId { get; set; }

        [ForeignKey(nameof(UrunId))]
        public Urun Urun { get; set; }

        [ForeignKey(nameof(GorselId))]
        public Gorsel Gorsel { get; set; }
    }
}
