/*
Assignment 1.3 – Problem Prompts

1. Area Calculator
Write a program in C# to calculate the area of triangle, square, and rectangle.
Write 3 different functions for each shape to take dimensions of the figure and display the area.
You may create menus.

------------------------------------------------------------

2. Array Declaration & Properties
Write a console application in C# to explore different ways in which arrays are declared and initialized,
and explore different properties and methods of the Array class.

------------------------------------------------------------

3. Reverse Array Display
Write a program in C# to read n number of values into an array and display them in reverse order.

Test Data:
Input the number of elements to store in the array: 3
Input 3 number of elements in the array:
element - 0 : 2
element - 1 : 5
element - 2 : 7

Expected Output:
The values stored into the array are:
2 5 7
The values stored in the array in reverse are:
7 5 2
*/

using System;// we import the buil-in tools

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