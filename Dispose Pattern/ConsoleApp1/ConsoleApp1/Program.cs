using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyClass myClass = new MyClass())
            {
                Console.WriteLine("Inside using statement");
            }

            //MyClass myClass = new MyClass();
            //myClass.Dispose();

            Console.ReadKey();
        }
    }
}
