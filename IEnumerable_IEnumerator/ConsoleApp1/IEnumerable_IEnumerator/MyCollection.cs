using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumerable_IEnumerator
{
    public class MyCollection : IEnumerable
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator();
        }

        public MyEnumerator GetEnumerator()
        {
            return new MyEnumerator();
        }
    }
}
