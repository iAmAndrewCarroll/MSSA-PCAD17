using Assignment2_1; // access to Part1 - Part 3 of todays assignment
using Assignment_Tools; // access to the Utilities.cs toolbox 

namespace Week_2 // this namespace reflects the folder structure - primary control for all Week2 work
{
    public class Program
    {
        // Main method: entry poitn of console application
        public static void Main(string[] args)
        {
            while (true) // infinite menu loop keeps us going if error or desire to retry
            {
                Console.Clear();
                Console.WriteLine("-- Week 2 Assignment 2.1 Menu --");
                Console.WriteLine("1 - Weightlifting Class Hierarchy (OOP)");
                Console.WriteLine("2 - ");
                Console.WriteLine("3 - ");
                Console.WriteLine("4 - Exit");
                Console.WriteLine("Choose an option: "); // inline prompt

                string choice = Console.ReadLine(); // reads user input
                Console.WriteLine(); // spacing

                // evaluate user choice and routes to correct PartX.Run()
                switch (choice)
                {
                    case "1":
                        Part1.Run(); // runs Assignment2_1.Part1
                        break;
                    case "2":
                        Part2.Run(); // runs Part2
                        break;
                    case "3":
                        Part3.Run();  // runs Part3
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!"); // exit message
                        Utilities.Delay(); // pause briefly before exit
                        return; // exits program
                    default:
                        Console.WriteLine("Invalid option."); // fallback for invalid input
                        Utilities.Pause(); // pause and return to menu
                        break;
                }
            }
        }
    }
}