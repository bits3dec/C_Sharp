using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            //Pass the CancellationToken and the number-to-count-to into the operation
            ThreadPool.QueueUserWorkItem((state) => Count(cts.Token, 20));

            Console.WriteLine("Press <Enter> to cancel the operation");
            Console.ReadLine();
            cts.Cancel();//If counting is done then the cancel() has no effect on it

            Console.ReadLine();
        }

        private static void Count(CancellationToken token, int countTo)
        {
            for(int count = 0; count < countTo; ++count)
            {
                if (token.IsCancellationRequested == true)
                {
                    Console.WriteLine("Counting is cancelled");
                    return;//Return from the operation
                }

                Console.WriteLine("Count = {0}", count);
                Thread.Sleep(200);
            }
            Console.WriteLine("Counting is done");
        }
    }
}
