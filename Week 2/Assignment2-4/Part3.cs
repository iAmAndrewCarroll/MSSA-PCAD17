/*
=======================================================================
PART3.cs – Assignment 2.4: Determine Coordinate Quadrant (Switch-Based)
=======================================================================

This module demonstrates:
- Using tuple-based pattern matching in a switch expression
- A tuple is a lightweight data structure in C# that can 
  hold a fixed number of items of possibly different types.
- Cleaner and more scalable logic than if/else ladders
- Applying C# 8.0+ features for clarity and precision

| Step | What Happens                                 | Where It Happens         |
|------|----------------------------------------------|--------------------------|
| 1    | Prompt user for X and Y input                | Utilities.ReadInt()      |
| 2    | Use switch with tuple pattern matching       | `switch (x, y)` block    |
| 3    | Print quadrant, axis, or origin accordingly  | Inside switch cases      |
| 4    | Pause before returning to main menu          | Utilities.Pause()        |
*/

using Assignment_Tools;
using System;

namespace Assignment2_4
{
    public class Part3
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("-- Assignment 2.4 Part 3: Quadrant Checker (Switch-based) --\n");

            // Step 1: Prompt the user for X and Y coordinates
            int x = Utilities.ReadInt("Enter X coordinate: "); // Read X input as integer
            int y = Utilities.ReadInt("Enter Y coordinate: "); // Read Y input as integer

            Console.WriteLine(); // blank line for visual separation

            // Step 2: Use a switch statement with tuple pattern matching
            switch (x, y) // We switch on a tuple of (x, y)
            {
                // Step 3: Match exact coordinate scenarios using pattern matching

                case (0, 0): // Both values are 0
                    Console.WriteLine("The point lies at the Origin.");
                    break;

                case (_, 0): // Y is 0, X can be anything (excluding 0 already matched)
                    Console.WriteLine("The point lies on the X-axis.");
                    break;

                case (0, _): // X is 0, Y can be anything (excluding 0 already matched)
                    Console.WriteLine("The point lies on the Y-axis.");
                    break;

                case ( > 0, > 0): // X > 0 and Y > 0
                    Console.WriteLine("The point lies in the First quadrant.");
                    break;

                case ( < 0, > 0): // X < 0 and Y > 0
                    Console.WriteLine("The point lies in the Second quadrant.");
                    break;

                case ( < 0, < 0): // X < 0 and Y < 0
                    Console.WriteLine("The point lies in the Third quadrant.");
                    break;

                case ( > 0, < 0): // X > 0 and Y < 0
                    Console.WriteLine("The point lies in the Fourth quadrant.");
                    break;

                default: // Just in case any weird combination sneaks through
                    Console.WriteLine("Unrecognized coordinate position.");
                    break;
            }

            // Step 4: Pause before returning to menu
            Utilities.Pause();
        }
    }
}
