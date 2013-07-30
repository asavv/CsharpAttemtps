using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionPointers_byJohn_2
{
    public delegate void FunctionPointer(int value);

    internal class Program
    {
        private static void Main(string[] args)
        {
            Human bob = new Human("Bob");
            Human sarah = new Human("Sarah");

            FunctionPointer pointers = null;
            pointers += bob.CallMyPhone;
            bob = null;
            pointers += Program.Number999;
            pointers += sarah.CallMyPhone;
            pointers += Program.Number07811105343;


            pointers(4); // executed the functions pointed by "pointers" function pointer.
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

    public class Human
    {
        public string Name;

        public Human(string name)
        {
            Name = name;
        }

        public void CallMyPhone(int stage)
        {
            Console.WriteLine("Hello. {0} speaking! I hear you are at stage {1}", Name, stage);
        }
    }
}
