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
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<int> task = Task.Run(() => Sum(10000000, cts.Token), cts.Token);

            //cts.Cancel();

            task.ContinueWith(t => Console.WriteLine("The sum is: " + t.Result), TaskContinuationOptions.OnlyOnRanToCompletion);

            task.ContinueWith(t => Console.WriteLine("Sum threw: " + t.Exception.InnerException), TaskContinuationOptions.OnlyOnFaulted);

            task.ContinueWith(t => Console.WriteLine("Sum was cancelled"), TaskContinuationOptions.OnlyOnCanceled);

            Console.ReadLine();
        }

        private static int Sum(int n, CancellationToken token)
        {
            int sum = 0;

            for( ; n > 0; --n)
            {
                token.ThrowIfCancellationRequested();

                //sum += n;
                checked { sum += n; }
            }

            return sum;
        }
    }
}
