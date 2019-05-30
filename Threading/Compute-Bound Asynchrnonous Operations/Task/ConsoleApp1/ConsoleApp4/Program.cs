using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int[]> parent = new Task<int[]>(() =>
                {
                    var res = new int[3];

                    new Task(() => res[0] = Sum(10000000), TaskCreationOptions.AttachedToParent).Start();
                    new Task(() => res[1] = Sum(200), TaskCreationOptions.AttachedToParent).Start();
                    new Task(() => res[2] = Sum(300), TaskCreationOptions.AttachedToParent).Start();

                    return res;
                }
            );

            parent.ContinueWith((task) => Array.ForEach<int>(task.Result, Console.WriteLine), TaskContinuationOptions.OnlyOnRanToCompletion);
            parent.ContinueWith((task) => Console.WriteLine("Task threw exception: " + task.Exception.InnerException), TaskContinuationOptions.OnlyOnFaulted);

            parent.Start();

            Console.ReadLine();
        }

        private static int Sum(int n)
        {
            int sum = 0;

            for(; n > 0; --n)
            {
                checked { sum += n; }
            }

            return sum;
        }
    }
}
