using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CokKatmanliMimari.Web.TasarimDesenleri
{
    public class Singleton
    {
        public static Singleton singleton = null;
        private Singleton()
        {
        }

        public static Singleton ObjeyiGetir()
        {
            if(singleton == null)
            {
                singleton = new Singleton();
            }
            return singleton;
        }
    }
}
