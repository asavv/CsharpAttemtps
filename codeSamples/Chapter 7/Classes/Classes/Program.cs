#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Classes
{
    class Program
    {
        
        static void DoWork()
        {
            Point origin = new Point();
            Point bottomRight = new Point(1024, 1280);

            // calling the method DistanceTo with object origin, sets 'this' to x=y=-1 . So 'this' refers to the object that called teh function.
            // and you use as arguments bottomRight, with sets 'other' as x=1028 and y=1280.
            double distance = origin.DistanceTo(bottomRight);  



            Console.WriteLine("Distance is: {0}", distance);

            Console.WriteLine("Number of point objects: {0}",Point.ObjectCount());
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
