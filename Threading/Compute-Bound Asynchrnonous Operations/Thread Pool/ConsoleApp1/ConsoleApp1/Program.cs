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
            Console.WriteLine("Main thread: Queuing an entry to thread pool queue");
            ThreadPool.QueueUserWorkItem(CompountboundOp, 5);

            Console.WriteLine("Main thread doing some other work here...");
            Thread.Sleep(10000);//simulating a work for 10 sec
            Console.WriteLine("Hit <Enter> to end this program");

            Console.ReadLine();
        }

        private static void CompountboundOp(Object state)
        {
            Console.WriteLine("Thread pool thread: Inside CompountboundOp state = {0}", state);
            Thread.Sleep(1000);//simulating a work for 1 sec

            //Thread pool thread doesnot die after returning from the method rather
            //goes to idle state and waits for the next operation request
        }
    }
}
