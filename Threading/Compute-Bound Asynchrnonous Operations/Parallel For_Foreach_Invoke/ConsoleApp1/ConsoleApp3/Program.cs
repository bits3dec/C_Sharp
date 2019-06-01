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
            DateTime startTime;
            DateTime endTime;
            TimeSpan span;
            int ms;

            startTime = DateTime.Now;
            List<int> integerList = Enumerable.Range(1, 10).ToList(); //returns a sequence within the specified range 
            foreach (var item in integerList)
            {
                long total = DoSomeIndependentTimeConsumingTask();
                Console.WriteLine($"i = {item}, total = {total}, threadID = {Thread.CurrentThread.ManagedThreadId}");
            };
            endTime = DateTime.Now;
            span = endTime - startTime;
            ms = (int)span.TotalMilliseconds;
            Console.WriteLine($"Time Taken by foreach Loop in miliseconds {ms}");

            startTime = DateTime.Now;
            Parallel.ForEach(integerList, item =>
            {
                long total = DoSomeIndependentTimeConsumingTask();
                Console.WriteLine($"item = {item}, total = {total}, threadID = {Thread.CurrentThread.ManagedThreadId}");
            });
            endTime = DateTime.Now;
            span = endTime - startTime;
            ms = (int)span.TotalMilliseconds;
            Console.WriteLine($"Time Taken by Parallel's static ForEach Loop in miliseconds {ms}");

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
