using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Soyut
    {
        public abstract int a { get; set; }
        public int b{ get; set; }
        public abstract int DegerGetir(string anahtar);

        public void Karsila(string ad)
        {
            Console.WriteLine("Merhaba " + ad);
        }
    }
}
