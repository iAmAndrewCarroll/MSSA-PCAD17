using System;
using Assignment_Tools;
using Challenge_Labs;

namespace Week_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-- Week 2 Challenge Labs Menu --");
                Console.WriteLine("1 - Temperature Message");
                Console.WriteLine("2 - Login with 3 Attempts");
                Console.WriteLine("3 - Triangle Builder");
                Console.WriteLine("4 - Student Report (Struct/Class)");
                Console.WriteLine("5 - Exit");
                Console.Write("\nChoose an option: ");

                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1":
                        Part1.Run(); // Temperature logic
                        break;
                    case "2":
                        Part2.Run(); // Login with 3 tries
                        break;
                    case "3":
                        Part3.Run(); // Triangle output
                        break;
                    case "4":
                        Part4.Run(); // Student grade calc
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        Utilities.Delay();
                        return;
                    default:
                        Console.WriteLine("Invalid selection.");
                        Utilities.Pause();
                        break;
                }
            }
        }
    }
}
