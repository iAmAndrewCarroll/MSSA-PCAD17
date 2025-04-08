using System;
using System.Reflection.Metadata.Ecma335; // access to built in C# functionality

namespace Assignment1_2 // helps organize files under main project
{
    public class Part1 // defines the class that groups everything for this portion of assignment
    {
        public static void Run() // method that the main menu will call when Part 1 is selected
        {
            while (true) // loop to allow retry or exit to main menu
            {
                Console.Write("Input 1st number: "); // prompt user to enter value
                double num1 = double.Parse(Console.ReadLine()); // converts text input to decimal number (double data type)

                Console.Write("Input 2nd number: "); // prompt user 
                double num2 = double.Parse(Console.ReadLine()); // converts text input to decimal number (double data type

                if (num1 == num2) // == checks if the values are exactly the same
                    Console.WriteLine($"{num1} and {num2} are equal"); // if values are exactly the same this prints
                else
                    Console.WriteLine($"{num1} and {num2} are not equal"); // if values are not exactly the same this prints

                // ask what to do next so we aren't kicked out to the main menu
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1 - Try Again");
                Console.WriteLine("2 - Return to Main Menu");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine(); // spacing & readability
                        continue;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Default to main.");
                        return;
                }
            }
        }
    }
}

// Write keeps the cursor on the same line
// WriteLine pushes the cursor to the next line below
// switch is much cleaner to read in a scenario where if/else statements get long.
// I wanted to practice switch and it saves a little time.