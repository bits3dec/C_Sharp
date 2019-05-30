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
            Console.WriteLine("Main Thread: Creating dedicated thread");
            Thread dedicatedThread = new Thread(ComputeBoundOperation);

            /*
            Operating system thread will only be created if start() is called
            The argument passed is for the parameter of the call back method ComputeBoundOperation(Object state) 
            */
            dedicatedThread.Start(5);

            Console.WriteLine("Main thread: Doing some other work here...");
            Thread.Sleep(10000);//Simulating a work for 10 secs

            dedicatedThread.Join();//Wait for the dedicated thread to terminate
            Console.WriteLine("Hit <Enter> to end this program...");
            Console.ReadLine();
        }

        private static void ComputeBoundOperation(Object state)
        {
            Console.WriteLine("Inside ComputeBoundOperation through dedicated thread: state: {0}", state);
            Thread.Sleep(1000);//Simulating a work for 1 sec

            //when the method returns the thread dies
        }
    }
}
