using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIWithEFC.Models
{
    public class Sayilar
    {
        public Sayilar()
        {

        }

        public Sayilar(int sayi)
        {
            Sayi = sayi;
        }

        public int Id { get; set; }
        public int Sayi { get; set; }
    }
}
