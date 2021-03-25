using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoNetGiris.Models
{
    public class Kitap
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Tur { get; set; }
        public decimal Fiyat { get; set; }
        public int Yazar { get; set; }
    }
}
