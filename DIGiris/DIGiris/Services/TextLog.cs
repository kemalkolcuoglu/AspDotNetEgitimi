using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIGiris.Services
{
    public class TextLog : ILog
    {
        public TextLog()
        {
            Console.WriteLine("TextLog Nesnesi Olustu");
        }

        public void Log(string log)
        {
            Console.WriteLine(log);
        }
    }
}
