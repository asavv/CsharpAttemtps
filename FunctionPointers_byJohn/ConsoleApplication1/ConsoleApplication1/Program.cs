using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            ReadOnlyCollection<TimeZoneInfo> zones = TimeZoneInfo.GetSystemTimeZones();
            Console.WriteLine("The local system has the following {0} time zones", zones.Count);
            foreach (TimeZoneInfo zone in zones)
                Console.WriteLine(zone.Id);
        }
    }
}
