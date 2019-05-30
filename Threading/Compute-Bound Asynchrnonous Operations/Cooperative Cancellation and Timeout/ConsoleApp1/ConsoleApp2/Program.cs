using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Token.Register(() => Console.WriteLine("Canceled 1"));
            cts.Token.Register(() => Console.WriteLine("Canceled 2"));
            cts.Token.Register(() => Console.WriteLine("Canceled 3"));

            ThreadPool.QueueUserWorkItem((state) => Console.WriteLine("Operation 1"));
            
            Console.WriteLine("Press <Enter> to cancel the operation");
            Console.ReadLine();
            cts.Cancel();

            Console.ReadLine();
        }
    }
}
