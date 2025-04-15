/*
===========================================================
PART2.cs – Assignment 2.3: Tip Calculator with Formatting
===========================================================

This module demonstrates:
- Reading a bill total and tip % from the user
- Calculating the tip amount and grand total
- Using format specifiers to display values with currency ($) and percentage (%)

Flow Summary:
| Step | What Happens                                          | Where It Happens                           |
|------|-------------------------------------------------------|--------------------------------------------|
| 1    | User enters the bill total                            | `Utilities.ReadDouble("Enter bill: ")`     |
| 2    | User enters the tip percentage                        | `Utilities.ReadDouble("Enter tip %: ")`    |
| 3    | Tip amount is calculated (bill * tip / 100)           | Local variable `tipAmount`                 |
| 4    | Grand total is calculated (bill + tip)                | Local variable `grandTotal`                |
| 5    | Output values formatted as currency and percent       | `{value:C}` and `{value:P}` in WriteLine   |
| 6    | Pause before returning to menu                        | `Utilities.Pause()`                        |
*/

using System;
using Assignment_Tools;

namespace Assignment2_3
{
    public class Part2
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("-- Assignment 2.3 Part 2: Tip Calculator --\n");

            // Step 1. Get the bill amount from user
            double bill = Utilities.ReadDouble("Enter bill total: ");

            // Step 2: Get the tip percentage
            double tipPercent = Utilities.ReadDouble("Enter tip percentage: ");

            // Step 3: Calculate tip amount
            double tipAmount = bill * (tipPercent / 100);

            // Step 4: Calculate the final amount due
            double grandTotal = bill + tipAmount;

            // Step 5: Output all values with formatting
            Console.WriteLine();
            Console.WriteLine($"Bill Total : {bill:C}"); // {value:C} = Currency
            Console.WriteLine($"Tip ({tipPercent}%): {tipAmount:C}");
            Console.WriteLine($"Grand Total: {grandTotal:C}");

            // Step 6: Pause before exiting
            Utilities.Pause();
        }
    }
}