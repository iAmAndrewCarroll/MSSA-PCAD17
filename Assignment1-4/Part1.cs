using System;                           // I need this to use core classes like Console and basic data types
using Toolbox;                          // I import my custom utilities so I can use methods like ReadDouble and PromptFollowUpMenu

namespace Assignment1_4                 // I use this namespace to group all parts of Assignment 1.4 into a logical project section
{
    public class Part1                  // This class contains all the logic for comparing two points by their X-coordinates
    {
        public static void Run()        // This is the entry point for Part 1 — it's called from Program.cs when the user selects this module
        {
            while (true)               // I loop until the user chooses to exit — this allows the tool to repeat without restarting the program
            {
                Console.WriteLine("\n-- Point Comparison Tool --"); // I print a title so the user knows which tool is running

                // Prompt the user to enter the X and Y coordinates for Point 1
                double p1x = Utilities.ReadDouble("Enter X for Point 1: "); // I read a decimal value for the X-coordinate of Point 1
                double p1y = Utilities.ReadDouble("Enter Y for Point 1: "); // I read a decimal value for the Y-coordinate of Point 1

                // Prompt the user to enter the X and Y coordinates for Point 2
                double p2x = Utilities.ReadDouble("Enter X for Point 2: "); // I read the X-coordinate for Point 2
                double p2y = Utilities.ReadDouble("Enter Y for Point 2: "); // I read the Y-coordinate for Point 2

                // Create the Point objects using object initializer syntax
                Point p1 = new Point { X = p1x, Y = p1y }; // I create a new Point object and assign the X and Y values entered for Point 1
                Point p2 = new Point { X = p2x, Y = p2y }; // I do the same for Point 2

                // Compare the X-coordinates to determine spatial relationship
                if (p2.X > p1.X)                            // If P2's X is greater, then it's to the right of P1
                    Console.WriteLine("\nPoint 2 is to the right of Point 1."); // Inform the user of the spatial relationship
                else if (p2.X < p1.X)                       // If P2's X is smaller, it's to the left
                    Console.WriteLine("\nPoint 2 is to the left of Point 1.");
                else                                        // If both X values are equal, then the points align vertically
                    Console.WriteLine("\nPoint 2 is aligned vertically with Point 1 (same X).");

                // Offer the user a follow-up menu with options
                switch (Utilities.PromptFollowUpMenu(new[] { "Try Another", "Return to Main Menu" })) // I ask the user what they want to do next
                {
                    case "1":                               // If they choose 1, try again
                        Console.Clear();                    // I clear the screen before restarting for clarity
                        continue;                           // Jump to top of the while loop
                    case "2":                               // If they choose 2, exit this part
                        Console.Clear();                    // Clear the console before exiting
                        return;                             // Return exits the Run() method
                    default:                                // Handle any unexpected input
                        Console.WriteLine("Invalid choice. Returning to Main Menu..."); // Notify user of fallback behavior
                        return;
                }
            }
        }

        // NOTE: Instructor changed the requirement to use a class instead of a struct for Point.
        // The following struct was originally used for performance and simplicity, but it's now commented out.
        //public struct Point
        //{
        //    public double X;
        //    public double Y;
        //}
    }

    public class Point                  // I define a Point class with public properties for X and Y
    {
        public double X { get; set; }   // Property for the X-coordinate — public so it can be set from outside the class
        public double Y { get; set; }   // Property for the Y-coordinate — same pattern
    }
}
