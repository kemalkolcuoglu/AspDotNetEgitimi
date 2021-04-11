using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CokKatmanliMimari.Web.TasarimDesenleri
{
    public class CarparakHesapla : CarpmaIslemi
    {
        public override int Hesapla(int carpilan, int carpan)
        {
            return carpilan * carpan;
            /*
             * 4 * 3 = 12
             */
        }
    }
}
