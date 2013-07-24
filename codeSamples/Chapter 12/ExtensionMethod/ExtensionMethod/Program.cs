using System;
using Extensions;

namespace ExtensionMethod
{
    class Program
    {
        static void DoWork()
        {
            Console.WriteLine("\n ===CONVERT NUMBER FROM BASE 10 TO ALL BASES BETWEEN 2 AND 10.=== \n\n");
            Console.WriteLine("Please insert an integer value:");

            string line = Console.ReadLine();
            int x = Convert.ToInt32(line) ;

            for (int i = 2; i <= 10; i++)
            {
                Console.WriteLine("{0} in base {1} is {2}", x, i, x.ConvertToBase(i));
            }
        }

        static void Main()
        {
            try
            {
                DoWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }
    }
}
