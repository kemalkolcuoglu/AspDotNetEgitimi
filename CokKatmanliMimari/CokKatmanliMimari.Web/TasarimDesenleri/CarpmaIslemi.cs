using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CokKatmanliMimari.Web.TasarimDesenleri
{
    public abstract class CarpmaIslemi
    {
        public int carpilan;
        public int carpan;
        public abstract int Hesapla(int carpilan, int carpan);

        public void Merhaba()
        { 
            Console.WriteLine("Heeyy");
        }
    }
}
