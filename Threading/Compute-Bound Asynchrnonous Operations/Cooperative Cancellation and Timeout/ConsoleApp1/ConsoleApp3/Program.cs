using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts1 = new CancellationTokenSource();
            cts1.Token.Register(() => Console.WriteLine("cts1 canceled"));

            CancellationTokenSource cts2 = new CancellationTokenSource();
            cts2.Token.Register(() => Console.WriteLine("cts2 canceled"));

            CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token);
            linkedCts.Token.Register(() => Console.WriteLine("linkedCts canceled"));

            //Canceling one of the CancellationTokenSource object (say cts2)
            cts2.Cancel();
        
            //Canceling any of the linked CancellationTokenSource objects cancels the linkedCancellationTokenSource Object
            Console.WriteLine("cts1 canceled = {0}, cts2 canceled = {1}, linkedCts cancelled = {2}",
                               cts1.Token.IsCancellationRequested,
                               cts2.Token.IsCancellationRequested, 
                               linkedCts.Token.IsCancellationRequested);

            Console.ReadLine();
        }
    }
}
