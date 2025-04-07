using System;

namespace Assignment1_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true) // loop until user explicitly exits
            {
                Console.WriteLine("Which part of Assignment 1.1 do you want to run?");
                Console.WriteLine("1 - Personal Details");
                Console.WriteLine("2 - Sum of Two Numbers");
                Console.WriteLine("3 - Quotient & Remainder");
                Console.WriteLine("4 - Exit");
                Console.Write("Choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine(); // readability

                // menu options call the Run() method from the corresponding module
                if (choice == "1")
                {
                    Part1.Run();
                }
                else if (choice == "2")
                {
                    Part2.Run();
                }
                else if (choice == "3")
                {
                    Part3.Run();
                }
                else if (choice == "4")
                {
                    Exit.Run();
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }

                Console.WriteLine(); // readability between runs
            }  
        }
    }
}
