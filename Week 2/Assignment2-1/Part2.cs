/*
====================================================
PART2.cs – Method Overloading + Static Method Routing
====================================================

This table outlines the execution flow of the method
overloading menu. It shows how user choices trigger
different overloaded methods and how data is routed
through static calls.

| Step | What Happens                                          | Where It Happens                        |
|------|--------------------------------------------------------|-----------------------------------------|
| 1    | User selects option from method menu                  | `Console.ReadLine()`                    |
| 2    | Case 1–4 collects input based on selected overload    | `Utilities.ReadInt()` / `ReadDouble()`  |
| 3    | Matching overloaded method is called                  | `Maths.Add(...)` or `Maths.Multiply(...)` |
| 4    | Calculation result is stored in a local variable      | e.g. `intSum`, `decSum`, `fProduct3`     |
| 5    | Result is printed using interpolated string           | `Console.WriteLine(...)`               |
| 6    | Utilities.Pause() waits for user before next round    | `Utilities.Pause()`                    |
| 7    | Loop repeats until user selects "Return to Main Menu" | `case "5": return;`                    |

Concepts Reinforced:
---------------------
- Method overloading with different parameter signatures
- Static method calls (no object instantiation needed)
- DRY input via toolbox utilities
- Menu dispatch via `switch`
*/

using Assignment_Tools; // access to input validators and console helpers

namespace Assignment2_1
{
    public class Part2
    {
        // Run() is called from Program.cs when user selects this assignment module
        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-- Assignment 2.1 Part 2: Method Overloading Demo --");
                Console.WriteLine("This demonstrates:");
                Console.WriteLine("  - Static method calls");
                Console.WriteLine("  - Method overloading (same method name, different parameters)");
                Console.WriteLine("  - Type-specific operations (int, float, decimal)");
                Console.WriteLine();

                Console.WriteLine("Select an operation:");
                Console.WriteLine("1 - Add (int, int)");
                Console.WriteLine("2 - Add (decimal, decimal, decimal)");
                Console.WriteLine("3 - Multiply (float, float)");
                Console.WriteLine("4 - Multiply (float, float, float)");
                Console.WriteLine("5 - Return to Main Menu");
                Console.Write("Choice: ");

                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1":
                        int a = Utilities.ReadInt("Enter first integer: ");
                        int b = Utilities.ReadInt("Enter second integer: ");
                        int intSum = Maths.Add(a, b);
                        Console.WriteLine($"Result: {a} + {b} = {intSum}");
                        break;

                    case "2":
                        decimal d1 = Utilities.ReadDouble("Enter decimal #1: ");
                        decimal d2 = Utilities.ReadDouble("Enter decimal #2: ");
                        decimal d3 = Utilities.ReadDouble("Enter decimal #3: ");
                        decimal decSum = Maths.Add((decimal)d1, (decimal)d2, (decimal)d3);
                        Console.WriteLine($"Result: {d1} + {d2} + {d3} = {decSum}");
                        break;

                    case "3":
                        float f1 = (float)Utilities.ReadDouble("Enter float #1: ");
                        float f2 = (float)Utilities.ReadDouble("Enter float #2: ");
                        float fProduct = Maths.Multiply(f1, f2);
                        Console.WriteLine($"Result: {f1} * {f2} = {fProduct}");
                        break;

                    case "4":
                        float f4_1 = (float)Utilities.ReadDouble("Enter float #1: ");
                        float f4_2 = (float)Utilities.ReadDouble("Enter float #2: ");
                        float f4_3 = (float)Utilities.ReadDouble("Enter float #3: ");
                        float fProduct3 = Maths.Multiply(f4_1, f4_2, f4_3);
                        Console.WriteLine($"Result: {f4_1} * {f4_2} * {f4_3} = {fProduct3}");
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                Utilities.Pause(); // pause before next round
            }
        }
    }
}
