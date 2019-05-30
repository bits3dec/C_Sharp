using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerable
{
    public class MyEnumerator
    {
        private int step;
        public bool MoveNext()
        {
            if (step < 5)
            {
                ++step;
                return true;
            }

            Reset();
            return false;
        }

        public void Reset()
        {
            step = 0;
        }

        public int Current { get { return step; } }
    }
}

