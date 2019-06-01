using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Task<int> task = Task.Run(() => Sum(10000000, cts.Token), cts.Token);

            //Sometime later cancel the CancelltionTokenSource to cancel the task
            cts.Cancel();//This is Asynchronous request, the task may have completed already

            try
            {
                //If the task gets cancelled Result will throw an AggregateException
                Console.WriteLine("The sum is: " + task.Result);
            }
            catch(AggregateException ex)
            {
                //Handle invokes callBack for each exception contained in the AggregateException and then 
                //decide how to handle the exception
                //If after calling Handle there is still an unhandled exception then a new AggregateException is created 
                //containing the unhandled exceptions
                ex.Handle(x => x is OperationCanceledException);

                Console.WriteLine("Sum was cancelled");
            }

            Console.ReadLine();
        }

        private static int Sum(int n, CancellationToken token)
        {
            int sum = 0;

            for( ; n > 0; --n)
            {
                token.ThrowIfCancellationRequested();

                checked
                {
                    sum += n;
                }
            }

            return sum;
        }
    }
}
