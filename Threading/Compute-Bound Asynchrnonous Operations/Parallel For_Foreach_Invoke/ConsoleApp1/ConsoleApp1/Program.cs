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
            Console.WriteLine("Using sequential for loop");
            for(int i = 0; i < 10; ++i)
            {
                Console.WriteLine($"i = {i}, threadID = {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            }

            Console.WriteLine();

            Console.WriteLine("Using Parallel's static for loop");
            Parallel.For(0, 10, i => 
            {
                Console.WriteLine($"i = {i}, threadID = {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            });

            Console.ReadKey();
        }

    }
}
