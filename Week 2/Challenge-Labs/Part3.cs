/*
=======================================================================
PART3.cs – Week 2 Challenge: Triangle Builder (Number and Width)
=======================================================================

This module demonstrates:
- Using a loop to print a decreasing number of characters per line
- Repeating a character using `new string(char, count)`
- Simple loop-based output formatting

| Step | What Happens                                     | Where It Happens               |
|------|--------------------------------------------------|--------------------------------|
| 1    | Number and width are declared (hardcoded)        | Top of Part3.Run()             |
| 2    | A `for` loop starts from width and counts down   | `for (int i = width; i >= 1)`  |
| 3    | Each line prints the number `i` times            | `Console.WriteLine(...)`       |
| 4    | Program pauses before returning to menu          | `Utilities.Pause()`            |

Key Concepts:
- Loop control (countdown)
- String multiplication via `new string(...)`
- Formatting output for visual patterns
*/

using System;
using Assignment_Tools;

namespace Challenge_Labs
{
    public class Part3
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("-- Challenge Lab Part 3: Triangle Builder --\n");

            // step 1: Declare the number and width (hardcoded test values for now)
            int number = 6;
            int width = 6;

            Console.WriteLine($"Number: {number}");
            Console.WriteLine($"Width : {width}\n");

            // step 2: Print triangle using decreasing loop
            for (int i = width; i >= 1; i--)
            {
                // step 3: Print the number i times on each line
                Console.WriteLine(new string(char.Parse(number.ToString()), i));
            }

            // step 4: Pause before returning
            Utilities.Pause();
        }
    }
}