/*
=======================================================================
PART2.cs – Assignment 2.4: Find the Largest of Three Numbers
=======================================================================

This module demonstrates how to:
- Prompt for multiple inputs
- Use `if` statements to compare values
- Determine the largest number out of three user inputs

| Step | What Happens                                      | Where It Happens                      |
|------|---------------------------------------------------|---------------------------------------|
| 1    | Prompt user to input three integers               | `Utilities.ReadInt(...)`              |
| 2    | Assume the first is the largest                   | `int max = n1;`                       |
| 3    | Compare second and third numbers to the current max| `if (n2 > max)`, `if (n3 > max)`      |
| 4    | Update `max` if needed                            | Inside `if` blocks                    |
| 5    | Print the final result                            | `Console.WriteLine(...)`             |
| 6    | Wait for user before returning to the menu        | `Utilities.Pause()`                  |
*/

using Assignment_Tools;

namespace Assignment2_4
{
    public class Part2
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("-- Find Largetst of Three Numbers --\n");

            // Step 1: Get 3 integer from the user using validated input
            int n1 = Utilities.ReadInt("Enter 1st number: ");
            int n2 = Utilities.ReadInt("Enter 1st number: ");
            int n3 = Utilities.ReadInt("Enter 3rd number: ");

            // Step 2: Assume the first number is the largest for now
            int max = n1;

            // Step 3: Compare second to current max
            if (n2 > max)
                max = n2; // Step 4: Update max if n2 is greater

            // Step 5: Copmare third number to current max
            if (n3 > max)
                max = n3; // Step 6: Update max if n3 is greater

            // Step 7: Output the largest number
            Console.WriteLine($"\nThe largest number is: {max}");

            // Step 8: Wait for user
            Utilities.Pause();
        }
    }
}