using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class UrunGaleri
    {
        [Key]
        public int Id { get; set; }

        public int UrunId { get; set; }

        public int Yol { get; set; }

        [ForeignKey(nameof(UrunId))]
        public Urun Urun { get; set; }
    }
}
