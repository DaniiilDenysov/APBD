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
            Console.WriteLine("Please eter a number");
            int[] ints = { 1, 2, 3, 4, 5 };
            Console.WriteLine(CalculateAverage(ints));
            Console.WriteLine(GetMax(ints));
            if (int.TryParse(Console.ReadLine(), out int userInput)) {
                if (userInput < 0)
                {
                    Console.WriteLine("The value is less than 0");
                }
                else
                {
                    Console.WriteLine("The value is equal to 0 or higher");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer");
            }

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
        
        public static int GetMax(int [] ints)
        {
            int max = 0;
            for (int i = 1; i < ints.Length;i++)
            {
                if (ints[i] > ints[max]) max = i;
            }
            return ints[max];
        }
    }
}
