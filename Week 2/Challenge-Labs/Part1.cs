/*
=======================================================================
PART1.cs – Week 2 Challenge: Temperature to Message (Switch Expression)
=======================================================================

This version demonstrates:
- Refactoring conditional logic into a modern switch expression
- Using relational patterns (e.g. >=, <=) inside `switch`
- Assigning the matched result to a variable
- Using DRY principles with a single output line

| Step | What Happens                                       | Where It Happens            |
|------|----------------------------------------------------|-----------------------------|
| 1    | Declare a hardcoded temperature (test value)       | Top of Run()                |
| 2    | Use a switch expression to find the correct message| `temp switch { ... }`       |
| 3    | Print result in a single, DRY output line          | `Console.WriteLine(message)`|
| 4    | Pause before returning to main menu                | `Utilities.Pause()`         |

Key Concepts:
- Pattern matching in a switch
- Expression-based control flow
- Clean, composable logic
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
            Console.WriteLine("-- Challenge Lab Part 1: Temperature Message (Refactored) --\n");

            // Step 1: Use a hardcoded test temperature for evaluation
            int temp = 67;

            Console.WriteLine($"Input Temperature: {temp}\u00B0F\n"); // \u00B0 = degree symbol

            // Step 2: Use a switch expression to evaluate the range
            // This assigns the matched result directly to a variable
            string message = temp switch
            {
                >= 0 and <= 10 => "Freezing weather.",
                >= 11 and <= 20 => "Very cold weather.",
                >= 21 and <= 35 => "Cold weather.",
                >= 36 and <= 50 => "Normal weather.",
                >= 51 and <= 65 => "It's hot.",
                >= 66 and <= 80 => "It's very hot.",
                _ => "Temperature out of expected range. Goodbye..."
            };

            // Step 3: Print the message returned by the switch expression
            Console.WriteLine(message);

            // Step 4: Pause before returning to menu
            Utilities.Pause();
        }
    }
}

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

/*
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
*/