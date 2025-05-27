/*
Assignment – Structures and Class Properties

1. Structure: Point
Create a structure named “Point” with 2 data members: X and Y coordinates.
Declare 2 points: P1 and P2.
Determine if P2 is to the right, left, or on the same vertical axis as P1 by comparing the X coordinates.
(If P1.X is more than P2.X, it is to the right.)

------------------------------------------------------------

2. Class: Student
Write a class named “Student” with the following private data members:
- StudentId (int)
- StudentFname (string)
- StudentLname (string)
- StudentGrade (char)

Create public properties for each data member (get/set).
Instantiate the class, assign data using the properties, and display the data on the console.
*/

using System;
using System.Runtime.InteropServices;
using Toolbox; // access to Utilities.cs

namespace Assignment1_4 // this organizes code into logical groups
{
    public class Program // public makes a class or method accessible from other places
                         // class: container for methods and variables
    {
        public static void Main(string[] args) // static: tied to the class itself; no object required
                                               // void: the method doesn't return a value
        {
            while (true)
            {
                // menu title and options using Utilities.cs for DRY formatting
                string choice = Utilities.DisplayMenu("Assignment 1.4 Menu", new[]
                {
                    "Compare Two Points",
                    "Create & Display Trainee Object",
                    "Leet Code Palindrome",
                    "Exit"
                });

                switch (choice)
                {
                    case "1":
                        Part1.Run(); // calls logic to compare two points
                        break;
                    case "2":
                        Part2.Run(); // calls logic to create and display student data
                        break;
                    case "3":
                        LeetPalindrome.Run(); // leet code palindrome
                        break;
                    case "4":
                        Console.WriteLine("Goodbye.");
                        Utilities.Delay();
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;

                }
            }
        }
    }
}