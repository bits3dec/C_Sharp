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
            Task parent = new Task(() =>
            {
                var cts = new CancellationTokenSource();
                //Pass the default values in the constructor of the TaskFactory
                TaskFactory<int> tf = new TaskFactory<int>(cts.Token, TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

                //Create child tasks using the task factory. All the child task will have the same configuration as specified in the
                //task factory constructor
                var childTasks = new Task<int>[]
                {
                    //All the child task share the same configuration set by the task factory
                    tf.StartNew(() => Sum(cts.Token, 100)),
                    tf.StartNew(() => Sum(cts.Token, 200)),
                    tf.StartNew(() => Sum(cts.Token, int.MaxValue))
                };

                //Cancels all the child tasks if any one of the child task throws an exception
                for(int i = 0; i < childTasks.Length; ++i)
                    childTasks[i].ContinueWith(t => cts.Cancel(), TaskContinuationOptions.OnlyOnFaulted);

                tf.ContinueWhenAll(
                    childTasks, 
                    completedTasks => completedTasks.Where(t => t.Status == TaskStatus.RanToCompletion)
                                                    .Max(t => t.Result), CancellationToken.None)
                        .ContinueWith(t => Console.WriteLine("The maximum sum is: " + t.Result), TaskContinuationOptions.ExecuteSynchronously);                               ;

            });

            parent.ContinueWith(t => Console.WriteLine("Show exception"), TaskContinuationOptions.OnlyOnFaulted);

            parent.Start();

            Console.ReadLine();
        }

        private static int Sum(CancellationToken token, int n)
        {
            int sum = 0;
            for( ; n > 0; --n)
            {
                token.ThrowIfCancellationRequested();
                checked { sum += n; }
            }

            return sum;
        }
    }
}
