using IEnumerable_IEnumerator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myCustomEnumerable = CustomEnumerable;

namespace ConsoleApp1
{
    public class Utility
    {
        //Using foreach without implementing the IEnumerable, IEnumerator
        public static void Iterate(myCustomEnumerable.MyCollection myCollection)
        {
            //With foreach i.e. internally it checks for GetEnumerator instance which should have HasNext and Current
            Console.WriteLine("-----With foreach using GetEnumerator-----");
            foreach (var next in myCollection)
            {
                Console.WriteLine(next);
            }

            Console.WriteLine("-----Without foreach using Enumerator the actual implementation of foreach-----");
            // foreach converts the above code into-
            var myEnumerator = myCollection.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                Console.WriteLine(myEnumerator.Current);
            }
        }

        //Enumerator retains the current state
        //Enumrable doesnot retain the current state
        public static void Iterate(MyCollection myCollection)
        {
            //Console.WriteLine("Using foreach which uses the GetEnumerator of IEnumerable");
            //foreach (var next in myCollection)
            //{
            //    if ((Int32)next >= 3)
            //        Iterate3to5eb(myCollection);
            //    else
            //        Console.WriteLine(next);
            //}

            Console.WriteLine("Without using foreach - using the enumerator instance to iterate");
            IEnumerator myEnumerator = myCollection.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                Console.WriteLine(myEnumerator.Current);
                if ((Int32)myEnumerator.Current >= 3)
                    Iterate3to5(myEnumerator);
            }
        }
        private static void Iterate3to5(IEnumerator enumerator)
        {
            Console.WriteLine("Inside Iterate3to5");
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
        private static void Iterate3to5eb(IEnumerable myCollection)
        {
            Console.WriteLine("Inside Iterate3to5eb");
            foreach (var next in myCollection)
            {
                Console.WriteLine(next);
            }
        }
    }
}
