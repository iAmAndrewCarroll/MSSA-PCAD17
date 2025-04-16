/*
=======================================================================
PART1.cs – Week 2 Challenge: Fahrenheit Temperature Message
=======================================================================

This module demonstrates:
- Using conditional branching to print a message based on temperature ranges
- Simple integer comparison using `if` / `else if`
- Using a hardcoded test value (e.g. 67°F)

| Step | What Happens                                    | Where It Happens           |
|------|-------------------------------------------------|----------------------------|
| 1    | Temperature is declared as a hardcoded int      | Top of Part1.Run()         |
| 2    | A chain of if/else statements checks the value  | Series of `if/else if`     |
| 3    | A matching message is printed                   | Inside the correct branch  |
| 4    | Program pauses before returning to menu         | `Utilities.Pause()`        |

Key Concepts:
- Integer comparison
- Conditional control flow
- Static test input for quick verification
*/

using System;
using Assignment_Tools;

namespace Challenge_Labs
{
    public class Part1
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("-- Challenge Lab Part 1: Temperature Message --\n");

            // Step 1: Use a hardcoded test temperature
            int temp = 67;

            Console.WriteLine($"Input Temp: {temp}\u00B0F\n");

            // Step 2-3: Use conditional logic to determin the correct message
            if (temp >= 0 && temp <= 10)
                Console.WriteLine("Freezing weather.");
            else if (temp >= 11 && temp <= 20)
                Console.WriteLine("Very cold weather.");
            else if (temp >= 21 && temp <= 35)
                Console.WriteLine("Cold weather.");
            else if (temp >= 36 && temp <= 50)
                Console.WriteLine("Normal weather.");
            else if (temp >= 51 && temp <= 65)
                Console.WriteLine("It's hot.");
            else if (temp >= 66 && tempt <= 80)
                Console.WriteLine("It's very hot.");
            else
                Console.WriteLine("Temperature out of expected range.  Goodbye...");

            // Step 4: Pause before returning to main menu
            Utilities.Pause();
        }
    }
}