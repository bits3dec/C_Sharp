using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IEnumerable_IEnumerator
{
    public class MyEnumerator : IEnumerator
    {
        private int step;
        public MyEnumerator()
        {
            step = 0;
        }

        public bool MoveNext()
        {
            if (step < 5)
            {
                ++step;
                return true;
            }

            return false;
        }

        public object Current { get { return step; } }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
