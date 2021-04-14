using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Somut : Soyut, IArayuz
    {
        public override int a { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int DegerGetir(string anahtar)
        {
            throw new NotImplementedException();
        }

        public void TabloYaz()
        {
            throw new NotImplementedException();
        }
    }
}
