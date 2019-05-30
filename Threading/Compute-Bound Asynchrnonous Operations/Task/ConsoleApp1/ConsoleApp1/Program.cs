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
            Task<int> task = new Task<int>((n) => Sum((int)n), 1000);

            task.Start();//Start the task sometime later

            task.Wait();//Wait for the task to complete

            Console.WriteLine("The sum is: " + task.Result);

            Console.ReadLine();
        }

        private static int Sum(int n)
        {
            int sum = 0;

            for( ; n > 0; --n)
            {
                //Checked context throws arithmetic overflow exception
                //Unchecked context will not throw overflow exception rather it truncates the result
                checked
                {
                    sum += n;
                }
            }

            return sum;
        }
    }
}
