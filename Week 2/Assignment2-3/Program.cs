using Assignment2_3;
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
                Console.WriteLine("-- Assignment 2.3 Menu --");
                Console.WriteLine("1 - File Write/Read (Personal Details)");
                Console.WriteLine("2 - Tip Calculator");
                Console.WriteLine("3 - Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1":
                        Part1.Run(); // File I/O
                        break;
                    case "2":
                        Part2.Run(); // Tip calculator
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Utilities.Pause();
                        break;
                }
            }
        }
    }
}
