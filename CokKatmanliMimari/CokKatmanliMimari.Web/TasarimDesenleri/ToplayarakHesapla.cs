using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CokKatmanliMimari.Web.TasarimDesenleri
{
    public class ToplayarakHesapla : CarpmaIslemi
    {
        public override int Hesapla(int carpilan, int carpan)
        {
            int sayi = 0;
            for (int i = 0; i < carpan; i++)
            {
                sayi += carpilan;
            }
            return sayi;
            /* 
             4, 3 = 12
            4 + 4 + 4 = 12
             */
        }
    }
}
