#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Classes
{
        // used to represent the location of a point defined by a pair of x and y coordinates.
    class Point
    {
        private int x, y;
        private static int objCount = 0;

        // default contructor
        public Point()
        {
            this.x = -1;
            this.y = -1;

            objCount++;

            //what was initially in this constructor
            Console.WriteLine("Default contructor called.");
        }
        // constructor that prints coordinates on console
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;

            objCount++;

            //what was initially in this constructor
            Console.WriteLine("x:{0}, y:{1}", x, y);
        }

        public double DistanceTo(Point other)
        {
            int xDiff = this.x - other.x;
            int yDiff = this.y - other.y;

            return (Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2)));
        }

        public static int ObjectCount()
        {
            return objCount;
        }
    }
}
