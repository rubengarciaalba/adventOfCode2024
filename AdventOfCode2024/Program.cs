
using AdventOfCode2024.Day1;
using System.Data;

namespace AdventOfCode2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Advent of code challenge days:\n");
            Console.WriteLine("1 - Day 1");
            Console.WriteLine("2 - Day 2");
            Console.WriteLine("3 - Day 3");
            Console.WriteLine("x - Exit");

            var stop = false;

            while(!stop)
            {
                Console.WriteLine("\nType one number to choose");

                var dayStr = Console.ReadLine();

                if (dayStr != null && dayStr.ToLower() == "x")
                {
                    stop = true;
                    return;
                }

                if (!int.TryParse(dayStr, out var day))
                {
                    Console.WriteLine("You have to enter a int number or 'x' to exit.");
                }

                Console.WriteLine($"\nDay {day} solution:");
                Console.WriteLine("*************************\n");

                switch (day)
                {
                    case 1:
                        new Day1.Day1();

                        break;

                    case 2:
                        new Day2.Day2();
                        
                        break;
                    default:
                        Console.WriteLine($"There is not a valid class for day {day}");
                        break;
                }

                Console.WriteLine("\n*************************\n");
            }            
        }
    }
}
