#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace DailyRate
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).run();
        }

        public void run()
        {
            double fee = calculateFee();
            Console.WriteLine("Fee is {0} ",fee);
            fee = calculateFee(650.0);
            Console.WriteLine("Fee is {0} ", fee);
            fee = calculateFee(500.0,3);
            Console.WriteLine("Fee is {0} ", fee);

            Console.WriteLine();

            fee = calculateFee(dailyRate:375.0);
            Console.WriteLine("Fee is {0} ", fee);
            fee = calculateFee(noOfdays:4);
            Console.WriteLine("Fee is {0} ", fee);
            fee = calculateFee(thedailyRate: 375.0);
            Console.WriteLine("Fee is {0} ", fee);


            double dailyRate = readDouble("Enter your daily rate: ");
            int noOfdays = readInt("Enter the number of days: ");
            writeFee(calculateFee(dailyRate, noOfdays));
        }

        private void writeFee(double p)
        {
            Console.WriteLine("The consultant's fee is {0}", p*1.1);
        }

        private double calculateFee(double thedailyRate = 500.0, int noOfdays = 5)  // function with optional parameters
        {
            Console.WriteLine("calculate Fee using two optional parameters");
            return thedailyRate*noOfdays;
        }

        private double calculateFee(double dailyRate = 500.0)  // function with optional parameters
        {
            Console.WriteLine("calculate Fee using one optional parameters");
            int defaultNoOfDays = 1;
            return dailyRate * defaultNoOfDays;
        }

        private double calculateFee()
        {
            Console.WriteLine("calculateFee using hardcore values");
            double defaultDailyRate = 400.0;
            int defaultNoOfDays = 1;
            return defaultDailyRate*defaultNoOfDays;
        }

        private int readInt(string p)
        {
            Console.Write(p);
            string line = Console.ReadLine();
            return int.Parse(line);
        }

        private double readDouble(string p)
        {
            Console.Write(p);
            string line = Console.ReadLine();
            return double.Parse(line);
        }
    }
}
