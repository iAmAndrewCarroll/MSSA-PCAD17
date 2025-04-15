/*
====================================================================
PART1.cs – Assignment 2.4: Sum All Elements in an Integer Array
====================================================================

This module demonstrates how to:
- Use arrays to store multiple values of the same type (int)
- Collect user input into an array using a loop
- Calculate the sum of array elements using a `foreach` loop

| Step | What Happens                                       | Where It Happens                          |
|------|----------------------------------------------------|-------------------------------------------|
| 1    | Prompt user for number of elements                 | `Utilities.ReadInt(...)`                  |
| 2    | Create an array of that size                       | `new int[count]`                          |
| 3    | Loop from 0 to count-1                             | `for` loop using `i++`                    |
| 4    | Fill array using validated user input              | `numbers[i] = Utilities.ReadInt(...)`     |
| 5    | Loop through array to calculate total              | `foreach (int num in numbers)`            |
| 6    | Print the result                                   | `Console.WriteLine(...)`                  |
| 7    | Wait for user before returning to menu             | `Utilities.Pause()`                       |
*/

using Assignment_Tools; // helper methods

namespace Assignment2_4
{
    public class Part1
    {
        // Entry point for this assignment
        public static void Run()
        {
            Console.Clear(); // clear the screen for a fresh start
            Console.WriteLine("-- Sum All Elements in Array --\n");

            // Step 1: prompt user for elements
            int count = Utilities.ReadInt("Enter number of elements: ");

            // Step 2: Create empty array that size
            int[] numbers = new int[count];

            // Step 3 - 4: Fill array using validated input
            for (int i = 0; i < count; i++)
            {
                numbers[i] = Utilities.ReadInt($"Elements [{i}]: ");
            }

            // Step 5: Initialize a total and sum up all elements using foreach
            int sum = 0;
            foreach (int num in numbers)
                sum += num;

            // Step 6: output the total
            Console.WriteLine($"\nSum of all elements: {sum}");

            // Step 7: provide time for review before returning to main menu
            Utilities.Pause();
        }
    }
}