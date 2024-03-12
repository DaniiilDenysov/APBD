using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 1, 2, 3, 4, 5 };
            Console.WriteLine(CalculateAverage(ints));
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        public static int CalculateAverage(int [] ints)
        {
            int sum = 0;
            foreach (var i in ints)
            {
                sum += i;
            }
            return sum/ints.Length;
        }
    }
}
