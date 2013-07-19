#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace StructsAndEnums
{
    class Program
    {
        static void DoWork()
        {
            Month first = Month.January;
            Console.WriteLine(first);
            Console.WriteLine((int)first);
            first++;
            Console.WriteLine(first);
            Console.WriteLine((int) first);

            first = Month.December;
            Console.WriteLine(first);
            Console.WriteLine((int)first);
            first++;
            Console.WriteLine(first);
            Console.WriteLine((int)first);

            Date defaultDate = new Date();
            Console.WriteLine(defaultDate);

            Date weddingAnniversary = new Date(2010, Month.December, 2);
            Console.WriteLine(weddingAnniversary);

            Date weddingAnnivCopy;
            weddingAnnivCopy = weddingAnniversary;
            Console.WriteLine("Value of copy is {0}", weddingAnnivCopy);
            weddingAnnivCopy.AdvanceMonth();
            Console.WriteLine("New value of weddingAnniversary is {0}", weddingAnniversary);
            Console.WriteLine("Value of copy is {0}", weddingAnnivCopy);

            Console.WriteLine("\n\n");

            DateC weddingAnniversaryC = new DateC(2010, Month.December, 2);
            Console.WriteLine(weddingAnniversaryC);

            DateC weddingAnnivCopyC;
            weddingAnnivCopyC = weddingAnniversaryC;
            Console.WriteLine("Value of copy is {0}", weddingAnnivCopyC);
            weddingAnnivCopyC.AdvanceMonth();
            Console.WriteLine("New value of weddingAnniversary is {0}", weddingAnniversaryC);
            Console.WriteLine("Value of copy is {0}", weddingAnnivCopyC);
        }

        static void Main()
        {
            try
            {
                DoWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
