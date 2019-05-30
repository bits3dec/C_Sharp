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
            try
            {
                int n = 0;
                int res = Bridge(n);
                Console.WriteLine($"Main(): Inside try block res = {res}");
            }
            catch
            {
                Console.WriteLine("Main(): Inside catch block");
            }
            finally
            {
                Console.WriteLine("Main(): Inside finally block");
            }

            Console.WriteLine("Main(): Outside try catch block");

            Console.ReadKey();
        }

        private static int Bridge(int n)
        {
            try
            {
                Console.WriteLine("Bridge(): Inside try block");
                return DivideBy(n);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bridge(): Inside catch block");
                throw;
            }
            finally
            {
                Console.WriteLine("Bridge(): Inside finally block");
            }
        }

        private static int DivideBy(int n)
        {
            Print();
            Console.WriteLine("DivideBy(): Inside before processing");
            int res = 5 / n;
            Console.WriteLine("DivideBy(): Inside after processing");

            return res;
        }

        private static void Print()
        {
            Console.WriteLine("Print(): Inside Print");
        }
    }
}
