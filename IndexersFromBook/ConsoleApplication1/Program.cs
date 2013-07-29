using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexersTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            int adapted = 62;
            Console.WriteLine("Initial value of adapted variable {0}", adapted);
            IntBits bits = new IntBits(adapted);
            bool peek = bits[6];
            bool peek2 = bits[4];
            bits[0] = true;
            bits[3] = false;
            bool dig6bef = bits[5];
            bits[5] ^= true;
            bool dig6aft = bits[5];

            Console.WriteLine("New value of adapted variable {0}", bits);
        }

        struct IntBits
        {
            private int bits;

            public IntBits(int initialBitValue)
            {
                bits = initialBitValue;
            }
            public bool this[int index]
            {
                get { return (bits & (1 << index)) != 0; }
                set
                {
                    if (value)  // value is a keyword....
                    {
                        bits |= (1 << index);
                    }
                    else
                    {
                        bits &= ~(1 << index);
                    }
                }
            }
        }

    }
}
