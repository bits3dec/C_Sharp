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
            DateTime startTime;
            DateTime endTime;
            TimeSpan span;
            int ms;

            Console.WriteLine("Using sequential for loop");
            startTime = DateTime.Now;
            for(int i = 0; i < 10; ++i)
            {
                long total = DoSomeIndependentTimeConsumingTask();
                Console.WriteLine($"i = {i}, total = {total}, threadID = {Thread.CurrentThread.ManagedThreadId}");
            }
            endTime = DateTime.Now;
            span = endTime - startTime;
            ms = (int)span.TotalMilliseconds;
            Console.WriteLine($"Time consumed by the sequential for loop is (in miliseconds): {ms}");

            Console.WriteLine();

            Console.WriteLine("Using Parallel's static for loop");
            startTime = DateTime.Now;
            Parallel.For(0, 10, i =>
            {
                long total = DoSomeIndependentTimeConsumingTask();
                Console.WriteLine($"i = {i}, total = {total}, threadID = {Thread.CurrentThread.ManagedThreadId}");
            });
            endTime = DateTime.Now;
            span = endTime - startTime;
            ms = (int)span.TotalMilliseconds;
            Console.WriteLine($"Time consumed by the sequential for loop is (in miliseconds): {ms}");

            Console.ReadLine();
        }

        private static long DoSomeIndependentTimeConsumingTask()
        {
            //Do some time consuming indpendent task like long calculation or DB related activity
            long total = 0;
            for (int i = 0; i < 10000000; ++i)
                total += i;

            return total;
        }
    }
}
