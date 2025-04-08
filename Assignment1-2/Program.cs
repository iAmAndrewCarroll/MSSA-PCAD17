using System; // we import the buil-in tools

namespace Assignment1_2 // this organizes code into logical groups
{
    public class Program // public makes a class or method accessible from other places
                         // class: container for methods and variables
    {
        public static void Main(string[] args) // static: tied to the class itself; no object required
                                               // void: the method doesn't return a value
        {
            while (true)
            {
                Console.WriteLine("\n-- Assignment 1.2 Menu --");
                Console.WriteLine("1 - Check if two numbers are equal");
                Console.WriteLine("2 - Sum of first 10 natural numbers");
                Console.WriteLine("3 - Basic Calculator");
                Console.WriteLine("4 - Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                if (choice == "1") Part1.Run(); // Run() is the custom method name (like a function in Python)
                else if (choice == "2") Part2.Run();
                else if (choice == "3") Part3.Run();
                else if (choice == "4") return;
                else Console.WriteLine("Invalid choice.");
            }
        }
    }
}