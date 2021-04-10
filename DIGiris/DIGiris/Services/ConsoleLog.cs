using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIGiris.Services
{
    public class ConsoleLog : ILog
    {
        public ConsoleLog()
        {
            Console.WriteLine("ConsoleLog Nesnesi Olustu");
        }

        public void Log(string log)
        {
            Console.WriteLine(log);
        }
    }
}
