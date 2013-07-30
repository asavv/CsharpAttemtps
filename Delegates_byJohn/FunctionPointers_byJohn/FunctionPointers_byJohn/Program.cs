using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionPointers_byJohn
{
    public delegate void BuilderProgressCallback(int stage);

    public class House
    {
        private int mStageReached;

        public int StageReached
        {
            get { return mStageReached; }
            set { mStageReached = value; }
        }
    }

    public class HouseBuilder
    {
        private readonly BuilderProgressCallback mCallback;

        public HouseBuilder(BuilderProgressCallback callback)
        {
            mCallback = callback;
        }

        /// <summary>
        /// I promise to call your number every time I complete a stage of work, should you have given me a number.
        /// </summary>
        /// <returns></returns>
        public House BuildHouse()
        {
            House house = new House();
            house.StageReached = 1;
            if (mCallback != null) mCallback(1);
            house.StageReached = 2;
            if (mCallback != null) mCallback(2);
            house.StageReached = 3;
            if (mCallback != null) mCallback(3);
            house.StageReached = 4;
            if (mCallback != null) mCallback(4);
            house.StageReached = 5;
            if (mCallback != null) mCallback(5);
            return house;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            HouseBuilder bob = new HouseBuilder(Number999);
            HouseBuilder amy = new HouseBuilder(Number07811105343);
            House houseBob = bob.BuildHouse();
            House houseAmy = amy.BuildHouse();

        }

        private static void Number07811105343(int stage)
        {
            Console.WriteLine("Stage {0} complete.", stage);
        }

        private static void Number999(int stage)
        {
            Console.WriteLine("You are wasting police time!", stage);
        }
    }
}
