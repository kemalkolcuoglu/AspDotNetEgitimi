using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Task t = new Task(() =>
            //{
            //    Task.Run(() =>
            //    {
            //        Console.WriteLine("Task icerideki yazi");
            //        Thread.Sleep(2000);
            //    });
            //});
            //t.Start();
            //Task t = Asenkron.ShowTodaysInfoAsync();
            await Asenkron.ShowTodaysInfoAsync();
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World 2");
            // Task icerisindeki yazi
            // Hello World
        }
    }
}
