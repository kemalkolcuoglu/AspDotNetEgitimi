using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Asenkron
    {
        public static async Task ShowTodaysInfoAsync()
        {
            string message = $"Today is {DateTime.Today:D}\n Today's hours of leisure: " + $"{await GetLeisureHoursAsync()}";
            Console.WriteLine(message);
        }

        static async Task<int> GetLeisureHoursAsync()
        {
            DayOfWeek today = await Task.FromResult(DateTime.Now.DayOfWeek);

            int leisureHours = today is DayOfWeek.Saturday || today is DayOfWeek.Sunday ? 16 : 5;

            //Üstteki gösterimin uzun hali
            //if (today is DayOfWeek.Saturday || today is DayOfWeek.Sunday)
            //    leisureHours = 16;
            //else
            //    leisureHours = 5;

            return leisureHours;
        }
    }
}
