using System;
using System.Net.Http.Headers; // we import the buil-in tools

namespace Assignment1_3 // this organizes code into logical groups
{
    public class Program // public makes a class or method accessible from other places
                         // class: container for methods and variables
    {
        public static void Main(string[] args) // static: tied to the class itself; no object required
                                               // void: the method doesn't return a value
        {
            while (true)
            {
                Console.WriteLine("\n-- Assignment 1.3 Menu --");
                Console.WriteLine("1 - Calculate Area");
                Console.WriteLine("1a - Fancy Area Calculator (Bonus)");
                Console.WriteLine("2 - Declare & Initiate Arrays");
                Console.WriteLine("3 - Read n Number of Values in an Array & Reverse Order");
                Console.WriteLine("3a - Bigger, Better, Bolder Arrays");
                Console.WriteLine("4 - Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Part1.Run(); // standard area calculator
                        break;
                    case "1a":
                        Part1_a.Run(); // fancy area calculator
                        break;
                    case "2":
                        Part2.Run(); // Declare and initiate arrays
                        break;
                    case "3":
                        Part3.Run(); // Read n Number of values in an array and reverse order
                        break;
                    case "3a":
                        Part3_a.Run(); // Bigger, Better, Bolder Arrays
                        break;
                    case "4":
                        return; // exit the app
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }

                //if (choice == "1") Part1.Run(); // Run() is the custom method name (like a function in Python)
                //else if (choice == "2") Part2.Run();
                //else if (choice == "3") Part3.Run();
                //else if (choice == "4") return;
                //else Console.WriteLine("Invalid choice.");
            }
        }
    }
}