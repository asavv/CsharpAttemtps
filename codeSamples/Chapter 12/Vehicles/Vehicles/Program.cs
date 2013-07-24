using System;

namespace Vehicles
{
    class Program
    {
        static void DoWork()
        {
            Console.WriteLine("Journey by airplane:");	
            Airplane myPlane = new Airplane();
            myPlane.StartEngine("Contact");
            myPlane.TakeOff();
            myPlane.Drive();
            myPlane.Land();
            myPlane.StopEngine("Whirr");

            Console.WriteLine("\n Journey by car:");
            Car myCar = new Car();
            myCar.StartEngine("Brm brm");
            myCar.Accelerate();
            myCar.Drive();
            myCar.Brake();
            myCar.StartEngine("Phu phut");

            Console.WriteLine("\n Testing polymorphism");
            Vehicle v = myCar;
            v.Drive();
            v = myPlane;
            v.Drive();

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
