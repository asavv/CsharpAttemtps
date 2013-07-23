#region Using directives
using System;
#endregion

namespace ParamsArray
{
	class Util
	{
        /// <summary>
        /// Returns the sum of all the values given in parameter list.
        /// </summary>
        /// <param name="paramList">Integer parameter list.</param>
        /// <exception cref="ArgumentException">Thrown when parameter list is either empty or null.</exception>
        ///  <returns></returns>
		public static int Sum(params int[] paramList)
		{
            Console.WriteLine("Using parameter list.");
		    if (paramList == null)
		    {
		        throw new ArgumentException("Util.Sum: null parameter list");
		    }

            if (paramList.Length == 0)
            {
                throw new ArgumentException("Util.Sum: empty parameter list");
            }

		    int sumTotal = 0;

		    foreach (int i in paramList)
		    {
		        sumTotal += i;
		    }

		    return sumTotal;
		}

        public static int Sum(int param1 = 0, int param2 = 0, int param3 = 0, int param4 = 0)
        {
            Console.WriteLine("Using optional parameters.");
            int sumTotal = param1 + param2 + param3 + param4;
            return sumTotal;
        }
	}
}