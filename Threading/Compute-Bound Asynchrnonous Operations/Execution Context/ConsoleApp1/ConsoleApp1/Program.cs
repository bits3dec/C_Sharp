using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CallContext.LogicalSetData("Name", "Preetom");

            //Initiate a work to be done by a thread pool thread
            //The thread pool thread CAN access the logical call context data
            ThreadPool.QueueUserWorkItem((state) => Console.WriteLine("Name = {0}", CallContext.LogicalGetData("Name")));

            //Now suppress the flowing of the Main thread's execution context
            ExecutionContext.SuppressFlow();

            //Initiate some other work to be done by a thread pool thread
            //The thread pool thread CANNOT access the logical call context data
            ThreadPool.QueueUserWorkItem((state) => Console.WriteLine("Name = {0}", CallContext.LogicalGetData("Name")));

            //Restore the flowing of the Main thread's execution context in case
            //it employs more thread pool threads in the future
            ExecutionContext.RestoreFlow();
            ThreadPool.QueueUserWorkItem((state) => Console.WriteLine("Name = {0}", CallContext.LogicalGetData("Name")));

            Console.ReadLine();  
        }
    }
}
