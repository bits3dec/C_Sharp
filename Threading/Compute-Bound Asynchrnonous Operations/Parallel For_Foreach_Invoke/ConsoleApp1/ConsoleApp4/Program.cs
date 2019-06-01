using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integerList = Enumerable.Range(1, 10).ToList();
            
            Console.WriteLine("Default parallelism i.e. default degree of concurrency (");
            Parallel.ForEach(integerList, item =>
            {
                Console.WriteLine($"item = {item}, threadID = {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            });

            Console.WriteLine();

            Console.WriteLine("Restricting the parallelism using ParallelOptions");
            //Restricting the number of concurrent threads to be created during the execution of the paralled loop
            var parallelOptions = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 2
            };
            Parallel.ForEach(integerList, parallelOptions, item =>
            {
                Console.WriteLine($"item = {item}, threadID = {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            });
            Console.ReadLine();
        }
    }
}
