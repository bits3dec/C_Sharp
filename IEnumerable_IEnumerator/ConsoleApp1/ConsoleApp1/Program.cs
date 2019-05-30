using IEnumerable_IEnumerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myCustomEnumerable = CustomEnumerable;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //myCustomEnumerable.MyCollection myCustomEnumerableCollection = new myCustomEnumerable.MyCollection();
            //Console.WriteLine("Without implementing IEnumerable, IEnumerator");
            //Utility.Iterate(myCustomEnumerableCollection);

            //MyCollection myCustomCollection = new MyCollection();
            //Console.WriteLine("Implementing IEnumerable, IEnumerator");
            //Utility.Iterate(myCustomCollection);

            List<int> myList = new List<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);

            var myListCopy = myList.ToList();
            foreach (var next in myListCopy)
            {
                if (next == 3)
                    myList.Remove(3);
            }

            Console.ReadKey();
        }

        
    }
}