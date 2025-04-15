using Assignment2_4;
using Assignment_Tools;

namespace Week_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-- Assignment 2.4 Menu --");
                Console.WriteLine("1 - Sum All Array Elements");
                Console.WriteLine("2 - Find Largest of Three Numbers");
                Console.WriteLine("3 - Determine Coordinate Quadrant");
                Console.WriteLine("4 - Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1":
                        Part1.Run();
                        break;
                    case "2":
                        Part2.Run();
                        break;
                    case "3":
                        Part3.Run();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        Utilities.Pause();
                        break;
                }
            }
        }
    }
}
