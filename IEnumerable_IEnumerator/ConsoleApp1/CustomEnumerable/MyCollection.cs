using System;
using System.Collections.Generic;
using System.Text;

namespace CustomEnumerable
{
    public class MyCollection
    {
        public MyEnumerator GetEnumerator()
        {
            return new MyEnumerator();
        }
    }
}
