#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Parameters
{
    class Program
    {
        static void DoWork()
        {
            int i = 0;
            int j;

            Console.WriteLine("the value of i is: {0}",i);
            Pass.Value(i);
            Console.WriteLine("the value of i is: {0}", i);

            WrappedInt wi = new WrappedInt();
            Console.WriteLine("the value of Number is: {0}", wi.Number);
            Pass.Reference(wi);
            Console.WriteLine("the value of Number is: {0}", wi.Number);

            Console.WriteLine("the value of ref i is: {0}", i);
            Pass.Valueref(ref i);
            Console.WriteLine("the value of ref i is: {0}", i);

            //Console.WriteLine("the value of out j is: {0}", j); //cannot be used, as j was not initialised
            Pass.Valueout(out j);
            Console.WriteLine("the value of out j is: {0}", j);

        }

        static void Main(string[] args)
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
